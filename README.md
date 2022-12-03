# CMPE195B_SphereArena


# Build Instructions

Download Unity Hub + Unity Editor from https://unity.com/download

Open Command Prompt/ Terminal
git clone https://github.com/tylercruzsmith/CMPE195B_SphereArena.git

Open Unity Hub 
Select arrow to the right of "Open"
Select "Add project from disk"
Select folder "CMPE195B_SphereArena"

# To Install mlAgents (only needed for training model)
In Windows 10:
Dependencies: Python 3.7, pip

Create python virtual environment (venv) in project directory
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
py -m venv venv

venv\Scripts\activate

pip install numpy
pip install torch
pip install mlAgents

# Running mlAgents
mlagents-learn --run-id='runid'

Hit play on unity editor

