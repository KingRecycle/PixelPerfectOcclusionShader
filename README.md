# PixelPerfectOcclusionShader
 A way to check if specific objects are within the view of a camera by giving specific objects a unique color and checking if the colors are visible on a render texture using a compute shader.

 ## How to use:
 Add a 2nd camera and set the environment to be solid color. I use black with 0 alpha.
 Set the cameras culling mask to things you want to allow to block vision of the objects.
 Add the RunVisionComputeShader to the camera and add the VisibilityCompute shader to it.
 
 Apply the UniqueColorShader.shader to a material and give the gameobjects you want to track the material.
 What I do is have each gameobject have a child gameobject that is just the model with the unique color material and set it to a custom layer and make your main camera ignore this layer.

The RunVisionComputeShader has an array of ints which represent if object is seen or not (0 or 1).
It assumes the order is the same as the UniqueColorId.IDToGameObject static Dictionary.
