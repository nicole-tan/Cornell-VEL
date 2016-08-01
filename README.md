# Cornell Virtual Embodiment Lab

##Tracking
The tracking section uses Unity and C# scripts to create three CSV files that record the date-time stamps [to the millisecond for accuracy], position, and rotation of the HTC Vive headset as well as the left and right controllers. If the time is the same for recorded output, it will be displayed in the CSV file in the order head, left controller, right controller (the body part is also notated at the end of each recorded line).

###General 
The outputted information is determined by an absolute coordinate system, with the origin indicated by the ball at the center of the screen. 
The information is recorded immediately when the play button is pressed or when the build is executed. <br />
When the space button is pressed, the output stops being recorded to the CSV file. When it is pressed again, recording continues. <br /> 
To delete recorded output, press either the l, h, or r key [left controller, head, right controller respectively]. <br />
Once the application is quit, a series of new lines and a line of asterisk delimeters will be entered to separate run-through data. 

####Left and Right Controllers
If only one controller is being used, the RightController.csv file will contain the tracking information for that moving controller. When both controllers are active, the one that is leftmost in space is recorded as left. 

###Events
Events are recorded by pressing down the 'E' key. This records down the timestamp and event name, as well as the location and rotation for that particular event, making it easy to debug tracking movements. 

###Testing
1. Left hand: 
           Up and down 5x <br />
           Side to side 5x [right then left] <br />
           Back and forth 5x <br />
           Pitch 5x <br />
           Yaw 5x <br />
           Roll 5x <br />
2. Right hand: 
            Up and down 5x <br />
            Side to side 5x <br />
            Back and forth 5x <br />
            Pitch 5x <br />
            Yaw 5x <br />
            Roll 5x <br />
3. Head: 
      Down and up 5x <br />
      Side to side 5x <br />
      Back up, go forward 5x <br />
      Pitch 5x <br />
      Yaw 5x <br />
      Roll 5x 

##Character
The given character [secretary] is an imported model from Unity's free assets. The head and bodily motions of the headset and controllers are accurately reflected in the first person movements of the character. A mirror is set up in the scene in order to better debug movements. 

###Character Progress
The arms have been separated from the rest of the character mesh. The rigging within each of the arms allow for proper wrist movement. Also added on are controllers that are held within each hand. As of now, all wrist, elbow, and shoulder movement is accurately tracked with the exception of some wrist deformation when twisting the arms along the x-axis. The feet currently move alongside the head mounting device and rotate appropriately. Next to be implemented is adding two extra Vive controllers to the ankle area which will allow for an even more accurate array of tracked movement. 

###Character Scripting
The character's movements all correspond to a script, SteamVR_IK, that uses inverse kinematics to change the position and rotation for all of the arm and head body parts in accordance to the movements of the head mounting device and controllers. It allows for wrist turning and twisting as well as for elbow and shoulder movements. The character's feet move in accordance with the Foot Movement script which allows for the feet to mostly follow the movements of the head mounting device [with some positioning and rotational constraints]. 

###Character Functionality
Due to the PickupParent script, the user can currently pick up spheres and other GameObjects from the floor by pressing down the Trigger button. They can then proceed to throw the objects with accurate velocity by flinging their arms and releasing the Trigger button. In order to reset the GameObjects to their original positions, the user can press the Touchpad button.

###To Be Implemented
* Recording data in columns
* Kill fixed update --> judder change?
* Preferences screen where you can customize the username [for the file], the event name, saving to an existing file, etc 
* Remove toggling of keypresses for now
* Run in beta?
* Create a dialogue box that allows you to choose the user and will allow you to either create a new file or use an existing one
* Create a new file every single time a button is pressed
* Have a more visual way of viewing the data
* Customizable keypresses 
* High fidelity - networked second life VR spinoff
* Create customizable avatars and characters in VR
* Adding in new room dimensions and look 
* Perfecting the hand movements
* Scaling the human avatar with that shown on the screen --> Script according to the headset distance from floor
* Prevention of unnatural hand movements 
* Model the surrounding room 
* Create a GUI that allows users to add ID in, input1 -> output 1 -> percentage...input4 -> output4 -> percentage where percentages are gain [amount of movement], speed, and/or accuracy
* Balloon popping target practice game


###Helpful Links
*Rigging a skeleton in Maya: https://www.youtube.com/watch?v=gUPbbhnUXhY
Hope? https://www.youtube.com/watch?v=bls91XlQHSY, https://www.youtube.com/watch?v=KYY7qo0z5h8, https://www.youtube.com/watch?v=A12gtS4oOgo
*Was able to remove the upper arm rotation with the help of this link (http://serrarens.nl/passervr/inverse-kinematics-for-arms-in-unity-freeindie/) 




