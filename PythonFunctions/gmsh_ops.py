import gmsh

def initialize():
    gmsh.initialize()
    
def get_version() -> str:
    return str(gmsh.__version__)