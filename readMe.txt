Overview of what you did (i.e. what are the controls? Why this design?)
The game involves both competitive and cooperative plater where the players have to get all the items that match the reference dress form in the center of the screen.
For Competitive: There is only one instance of each object so the players have to get all the correct items ins their basket before the other player or before the timer runs out.
For Co-op: the players have to work together to get all the correct items in their shared basket before the time runs out.

Controls:
Use "WASD" to move around, press "E" to pickup and drop objects and use "I" to lock and unlock cursor so that you can click the UI buttons at the start.

• What was challenging?
The most challenging part was converting/creating functions and scripts that were compatible with unity networking. I wasn't able to get all of the values to sync on both players screens and sometimes had trouble getting the client to perform the same tasks as the host. The crosshair colour also stops changing when the client joins the game
I also attempted to have a world space UI for the players to choose the game mode instead of the camera overlay however, all the buttons kept getting pressed at once causing all the button functions to be called at once.
There was also an issue with he winning detection where it would for the co-op mode that I did not get the time to fix. I believe its due to he bools not being in sync.

• What went well (i.e. how did you solve the above challenges?).
I solved the challenges by finding work arounds for my issues when I could like the UI buttons that were mentioned above.
I also asked for help from the Professor and my peers when I could.


• The URL to your GitHub repository (if using Github).


• List each external asset you used and include the link, you may use your own but please
mention that it is yours.

Link to git hub:

External assets:

Sewing machine: https://free3d.io/model/24f71fbb#google_vignette
Wood cabinets, shelves, etc..: https://assetstore.unity.com/packages/3d/props/wood-stuff-312468

Baskets:https://assetstore.unity.com/packages/3d/props/interior/3d-model-pack-baskets-157025

Fabric materials:https://assetstore.unity.com/packages/2d/textures-materials/fabric/50-fabric-materials-vol01-326828




The pickup script was referenced from Bita's code.
The spools and dress form were modeled and textured by me last semester.