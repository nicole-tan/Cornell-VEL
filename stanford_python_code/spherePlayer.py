import viz, vizshape, vizact

class SpherePlayer(viz.VizNode):
	def __init__(self):
		#Add group nodes
		group = viz.addGroup()
		viz.VizNode.__init__(self, group.id)
		#Add Sphere Object
		self.sphere = vizshape.addSphere(radius=10, slices = 32, stacks = 32, flipFaces=True, cullFace=True, lighting=False)
		self.sphere.setParent(self.id)
		self.sphere.setEuler(30,0,0)
		#Make sphere trans by default
		self.sphere.alpha(0)
		#Add empty video object
		self.video = None
		
	#Create fade action for sphere
	def fadeSphere(self, alpha, time):
		self.fade = vizact.fadeTo(alpha,time=time)
		self.sphere.addAction(self.fade)
		
	#Add video object method
	def setVideo(self, v):
		#If existing video exists, remove it
		if self.video:
			self.video.remove()
		#Add video
		self.video = viz.addVideo(v)
		#Texture sphere with video
		self.sphere.texture(self.video)
		#Loop video by default
		self.video.loop()
		
	#Add play/pause video method	
	def playPauseToggle(self):
		playState = self.video.getState()
		if playState == viz.MEDIA_RUNNING:
			self.video.pause()
		else:
			self.video.play()
	
if __name__ == '__main__':
	import vizconnect, vizact
	viz.setMultiSample(8)
	vizconnect.go('vizconnect_dk2.py')
	viz.eyeheight(0)
	player = SpherePlayer()
	#Add water, NOT WORKING
	#water = viz.addChild('assets/models/water_big.osgb')
	#water.setPosition([0,3,-0.5])
	vizact.onkeydown(' ', player.playPauseToggle)
	vizact.onkeydown('1', player.fadeSphere, 1, 2)
	vizact.onkeydown('2', player.fadeSphere, 0, 2)
	vizact.onkeydown('3', player.setVideo, 'videos/take2_render_edit.mp4')
	
	
		