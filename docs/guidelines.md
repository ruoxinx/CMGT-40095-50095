# Using the Course in Google Colab

Note: the website version of this guide is the canonical version:
[docs/guidelines.html](./guidelines.html)

Google Colab is the recommended way for students to use this course. Most notebook-based modules can now be opened with one click from the course website, so students usually do not need to install anything.

## Recommended student workflow

1. Open the [module hub](./modules/index.html).
2. Choose the module for the week.
3. Click the `Launch in Colab` button on that module page.
4. In Colab, sign in with a Google account if prompted.
5. Run the notebook from top to bottom, one cell at a time.

## Direct Colab launch links

- [Data Visualization and Visual Analytics for the Built Environment](https://colab.research.google.com/github/ruoxinx/CMGT-40095-50095/blob/main/lectures/L02_construction_data_visualization/L02_construction_data_visualization.ipynb)
- [Environmental Sensing and Site Monitoring Systems](https://colab.research.google.com/github/ruoxinx/CMGT-40095-50095/blob/main/lectures/L05_construction_data_sensing/code/dht11_write.ipynb)
- [Construction Data Preprocessing and Quality Control](https://colab.research.google.com/github/ruoxinx/CMGT-40095-50095/blob/main/lectures/L06_construction_data_process/Lab_data_preprocess.ipynb)
- [Predictive Modeling for Construction Materials and Permitting](https://colab.research.google.com/github/ruoxinx/CMGT-40095-50095/blob/main/lectures/L07_ML_construction/Lab_ML_Construction.ipynb)
- [Computer Vision for Construction Safety Analytics](https://colab.research.google.com/github/ruoxinx/CMGT-40095-50095/blob/main/lectures/L08_DL_Construction/Hardhat_Detection_tutorial.ipynb)
- [Generative Models for Design Communication: Stable Diffusion](https://colab.research.google.com/github/ruoxinx/CMGT-40095-50095/blob/main/lectures/L20_gen_AI_design/Stable_diffusion.ipynb)
- [Generative Models for Design Communication: Tiny Diffusion](https://colab.research.google.com/github/ruoxinx/CMGT-40095-50095/blob/main/lectures/L20_gen_AI_design/tiny_diffusion.ipynb)
- [Generative Models for Design Communication: pix2pix](https://colab.research.google.com/github/ruoxinx/CMGT-40095-50095/blob/main/lectures/L20_gen_AI_design/pix2pix.ipynb)

## Tips for students with no coding background

- Read the markdown explanation before running the next code cell.
- Run only one cell at a time.
- If something breaks, restart from the top rather than skipping ahead.
- Use comments in your own copied notebook to explain what you think each step is doing.
- Focus on the construction question first, then the code second.

## If a module is not notebook-based

Some modules use guides, scripts, or setup documents instead of a single Colab notebook. In those cases, the module page will link to the most relevant files directly in GitHub.

## Optional local workflow

Students who prefer working locally can still clone the repository and run Jupyter, but this is optional:

```bash
git clone https://github.com/ruoxinx/CMGT-40095-50095.git
cd CMGT-40095-50095
jupyter lab
```
