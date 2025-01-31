{
 "cells": [
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "# **Practice Notebook: Data Preprocessing & Basic Descriptive Analysis**\n",
    "\n",
    "Welcome to this practice notebook! Here, we will:\n",
    "1. Create (or import) a simple construction-related dataset.\n",
    "2. Demonstrate common data preprocessing techniques (handling missing values, duplicates, etc.).\n",
    "3. Perform basic descriptive statistics and visualizations.\n",
    "\n",
    "This is a beginner-friendly notebook, so each step is explained in detail. Feel free to run each cell in order and play around with the code."
   ]
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "## 1. Importing Libraries\n",
    "\n",
    "We'll use Python's popular libraries for data analysis:\n",
    "- **pandas** for data manipulation and analysis.\n",
    "- **numpy** for numerical operations.\n",
    "- **matplotlib** and **seaborn** for data visualization."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "import pandas as pd\n",
    "import numpy as np\n",
    "import matplotlib.pyplot as plt\n",
    "import seaborn as sns\n",
    "\n",
    "# For cleaner, more modern visuals, let's set a style.\n",
    "sns.set_theme(style=\"whitegrid\")\n",
    "\n",
    "print(\"Libraries imported successfully!\")"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "## 2. Creating a Sample Dataset\n",
    "\n",
    "For demonstration, we'll create a small dataset simulating *construction projects*. Each row represents a specific project or a segment of a project. Our columns include:\n",
    "- **Project_ID**: Unique identifier for each project (some values may be duplicates intentionally to simulate data issues).\n",
    "- **Phase**: The phase of the project (e.g., Planning, Design, Construction, Maintenance).\n",
    "- **Location**: Site location.\n",
    "- **Cost**: Reported cost for that phase (in thousand dollars).\n",
    "- **Duration**: Duration of the phase in days.\n",
    "- **Defects_Count**: Number of defects or rework items recorded.\n",
    "- **Date**: A date the record was created.\n",
    "\n",
    "We'll intentionally introduce some missing values and duplicates to practice data cleaning."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "# Create a dictionary of lists to simulate raw data\n",
    "data = {\n",
    "    'Project_ID': [101, 102, 102, 103, 104, 104, 104, 105, 106, 106],\n",
    "    'Phase': ['Planning', 'Design', 'Construction', 'Construction', 'Planning', 'Construction', 'Maintenance', 'Design', 'Construction', 'Construction'],\n",
    "    'Location': ['Site A', 'Site B', 'Site B', 'Site C', 'Site A', 'Site A', None, 'Site D', 'Site E', 'Site E'],\n",
    "    'Cost': [50, 80, np.nan, 200, 40, 150, 100, 90, 180, 180],\n",
    "    'Duration': [30, 45, 60, 90, np.nan, 75, 120, 30, 90, 90],\n",
    "    'Defects_Count': [2, 5, 3, 8, 1, 6, None, 2, 7, 7],\n",
    "    'Date': [\n",
    "        '2024-01-05', '2024-02-10', '2024-03-15', '2024-03-20', \n",
    "        '2024-01-10', '2024-04-01', '2024-05-25', '2024-02-15', \n",
    "        '2024-04-05', '2024-04-05'  # Duplicate date example\n",
    "    ]\n",
    "}\n",
    "\n",
    "# Convert the dictionary into a pandas DataFrame\n",
    "df = pd.DataFrame(data)\n",
    "\n",
    "print(\"Raw Dataset:\")\n",
    "df"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "## 3. Exploratory View of the Data\n",
    "\n",
    "Let's see how many rows and columns we have, and check the first few records. This step helps us get a quick sense of what the data looks like."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "# Shape of the dataset\n",
    "print(\"Dataset shape (rows x columns):\", df.shape)\n",
    "\n",
    "# First 5 rows\n",
    "df.head()"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "## 4. Checking for Missing Values and Duplicates\n",
    "\n",
    "### 4.1 Missing Values\n",
    "We'll look at whether any columns have missing values. Missing or `NaN` values can arise from incomplete data entry, sensor failures, or manual collection errors. We can count them or visualize them.\n",
    "\n",
    "### 4.2 Duplicates\n",
    "We also suspect that there might be duplicate rows or repeated project entries. We will check for any **exact** duplicates in the dataset."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "# Count missing values per column\n",
    "print(\"Missing values per column:\")\n",
    "print(df.isna().sum())\n",
    "\n",
    "# Check for duplicates across entire rows\n",
    "duplicate_rows = df.duplicated()\n",
    "print(\"\\nNumber of duplicate rows:\", duplicate_rows.sum())\n",
    "\n",
    "# Display any duplicate rows\n",
    "if duplicate_rows.sum() > 0:\n",
    "    display(df[duplicate_rows])\n",
    "else:\n",
    "    print(\"No exact duplicate rows found.\")"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "## 5. Handling Missing Values\n",
    "\n",
    "There are various ways to handle missing values. In this example, we will:\n",
    "1. Drop rows that are entirely missing in **Location** (assuming Location is critical).\n",
    "2. Fill missing **Cost** or **Duration** using simple imputation (e.g., mean or median).\n",
    "3. Fill or drop missing values in **Defects_Count** based on assumptions.\n",
    "\n",
    "> **Tip:** In real scenarios, your choice depends on the nature of the data and domain knowledge (e.g., you might fill cost based on an average from similar project phases)."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "# Before we fix anything, let's make a copy of the original DataFrame\n",
    "df_clean = df.copy()\n",
    "\n",
    "# 1. Drop rows where Location is missing\n",
    "df_clean = df_clean.dropna(subset=['Location'])\n",
    "\n",
    "# 2. Fill missing Cost and Duration with their mean values\n",
    "mean_cost = df_clean['Cost'].mean()\n",
    "mean_duration = df_clean['Duration'].mean()\n",
    "\n",
    "df_clean['Cost'] = df_clean['Cost'].fillna(mean_cost)\n",
    "df_clean['Duration'] = df_clean['Duration'].fillna(mean_duration)\n",
    "\n",
    "# 3. Fill missing Defects_Count with 0 (assuming no record means no defects)\n",
    "# or we might choose mean/median if we expect defects to be under-reported.\n",
    "df_clean['Defects_Count'] = df_clean['Defects_Count'].fillna(0)\n",
    "\n",
    "# Check the result\n",
    "print(\"Missing values per column after cleaning:\")\n",
    "print(df_clean.isna().sum())\n",
    "df_clean"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "## 6. Removing or Resolving Duplicates\n",
    "\n",
    "We'll remove any exact duplicate rows. In real scenarios, you might need more nuanced methods if partial duplicates or repeated IDs are expected for legitimate reasons (e.g., multiple phases per project)."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "# Remove exact duplicates\n",
    "df_clean.drop_duplicates(inplace=True)\n",
    "print(\"Number of rows after removing duplicates:\", df_clean.shape[0])\n",
    "df_clean"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "## 7. Basic Descriptive Statistics\n",
    "\n",
    "Now we have a cleaner dataset. Let's explore some basic statistics:\n",
    "- **count, mean, std, min, max, quartiles**\n",
    "- We can look at each column separately (Cost, Duration, Defects_Count)."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "df_clean.describe()"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "### 7.1 Column-Wise Analysis\n",
    "\n",
    "- **Cost**: Average cost, range, etc.\n",
    "- **Duration**: Average time. \n",
    "- **Defects_Count**: Check how many defects are typically reported.\n",
    "\n",
    "We can also do a quick grouping by `Phase` to see average cost or durations per phase."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "# Grouping by Phase to see average cost and duration.\n",
    "df_clean.groupby('Phase')[['Cost','Duration','Defects_Count']].mean()"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "## 8. Correlation Analysis\n",
    "\n",
    "Sometimes we want to see if any variables are correlated, for instance, does **Cost** correlate with **Duration** or **Defects_Count**?\n",
    "\n",
    "We'll use `df_clean.corr()` to compute the correlation matrix. Then we'll create a heatmap with seaborn for easy visualization."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "# Calculate correlation matrix\n",
    "corr_matrix = df_clean.corr(numeric_only=True)\n",
    "print(corr_matrix)\n",
    "\n",
    "# Visualize using a heatmap\n",
    "plt.figure(figsize=(6, 4))\n",
    "sns.heatmap(corr_matrix, annot=True, cmap=\"Blues\")\n",
    "plt.title(\"Correlation Matrix\")\n",
    "plt.show()"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "## 9. Basic Data Visualization\n",
    "\n",
    "### 9.1 Histograms\n",
    "A **histogram** helps visualize the distribution of a numeric variable, e.g., Cost or Duration.\n",
    "\n",
    "### 9.2 Box Plots\n",
    "A **box plot** can help detect outliers and understand the quartiles (spread) of the data."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "# Histograms for Cost and Duration\n",
    "fig, axes = plt.subplots(1, 2, figsize=(10,4))\n",
    "sns.histplot(data=df_clean, x='Cost', bins=5, kde=True, ax=axes[0], color='skyblue')\n",
    "axes[0].set_title('Cost Distribution')\n",
    "\n",
    "sns.histplot(data=df_clean, x='Duration', bins=5, kde=True, ax=axes[1], color='salmon')\n",
    "axes[1].set_title('Duration Distribution')\n",
    "\n",
    "plt.tight_layout()\n",
    "plt.show()\n",
    "\n",
    "# Box plot for Defects_Count\n",
    "plt.figure(figsize=(5,4))\n",
    "sns.boxplot(data=df_clean, x='Defects_Count', color='lightgreen')\n",
    "plt.title('Defects Count Box Plot')\n",
    "plt.show()"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "### 9.3 Bar Chart\n",
    "\n",
    "We can also visualize the average cost by phase or the total cost by location using a bar chart."
   ]
  },
  {
   "cell_type": "code",
   "metadata": {},
   "source": [
    "# Bar chart for average cost by phase\n",
    "avg_cost_by_phase = df_clean.groupby('Phase')['Cost'].mean().sort_values()\n",
    "\n",
    "plt.figure(figsize=(6,4))\n",
    "sns.barplot(x=avg_cost_by_phase.index, y=avg_cost_by_phase.values, palette='viridis')\n",
    "plt.title('Average Cost by Phase')\n",
    "plt.ylabel('Cost (thousand USD)')\n",
    "plt.xlabel('Project Phase')\n",
    "plt.xticks(rotation=45)\n",
    "plt.show()"
   ],
   "execution_count": null,
   "outputs": []
  },
  {
   "cell_type": "markdown",
   "metadata": {},
   "source": [
    "## 10. Conclusion & Next Steps\n",
    "\n",
    "In this notebook, we demonstrated how to:\n",
    "1. Generate or import a dataset in **pandas**.\n",
    "2. Inspect missing values and duplicates.\n",
    "3. Perform basic data cleaning (dropping rows, filling missing data).\n",
    "4. Calculate descriptive statistics and interpret them.\n",
    "5. Visualize data distributions and relationships.\n",
    "\n",
    "### Next Steps:\n",
    "- **Data Exploration**: Try adding more variables and exploring different plots.\n",
    "- **Feature Engineering**: Create new features based on domain knowledge (e.g., cost per day, cost per defect).\n",
    "- **Machine Learning**: Experiment with predictive models for cost, duration, or defect likelihood.\n",
    "- **Real Data**: Apply these methods to real construction project data sets if available.\n",
    "\n",
    "Feel free to experiment with different methods of imputation, or test how removing outliers affects the results."
   ]
  }
 ],
 "metadata": {
  "kernelspec": {
   "display_name": "Python 3",
   "language": "python",
   "name": "python3"
  },
  "language_info": {
   "name": "python"
  }
 },
 "nbformat": 4,
 "nbformat_minor": 5
}
