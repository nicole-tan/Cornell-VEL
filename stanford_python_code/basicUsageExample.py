from vhil_devkit import *
import vhil_devkit

RIFT = False
PPT1 = False
HOME_POS = [0,1,0]

vhilGo(RIFT, PPT1, homePos=HOME_POS)#, mode=viz.FULLSCREEN)

ball = viz.add('ball.wrl')
ball.setPosition([0,2,4])