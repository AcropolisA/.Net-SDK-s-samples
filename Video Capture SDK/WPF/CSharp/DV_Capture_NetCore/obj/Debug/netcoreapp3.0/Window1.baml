   M S B A M L   `   `   `  ����[  WVisioForge.Controls.UI.NetCore, Version=11.3.20.0, Culture=neutral, PublicKeyToken=nulloPclr-namespace:VisioForge.Controls.UI.WPF;assembly=VisioForge.Controls.UI.NetCoreVisioForge.Controls.UI.WPF  5   k    DV Capture Demo WPF NetCore   DVCapture.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      _myPclr-namespace:VisioForge.Controls.UI.WPF;assembly=VisioForge.Controls.UI.NetCore     5   k   -   5          � Title$.  (DV Capture Demo - Video Capture SDK .Net��5      $��441.136��66   $��813.797��6G    � Icon$ visioforge_main_icon.ico��6�   .��5      � .+�5   
   	� -   5        $��	rbPreview��5   R   $��16��6   $��Right=�6"   $��
0,0,352,38q�6>   $��Bottom=�6c   $��77��6~    d� 	IsChecked$
 TrueY�6�   .��6�   	Preview6�   	� 5   
   -   5        $��	rbCapture��5   R   $��16��6   $��Right=�6"   $��
0,0,259,38q�6>   $��Bottom=�6c   $��77��6~   .��6�   	Capture6�   �� 5   
   -   5        $��btStart��5   M   $��23��6   $��Right=�6   $��
0,0,372,10q�69   $��Bottom=�6\   $��57��6w   $��SemiBold"�6�   .��6�   Start6�   �� 5	   
   -   5        $��btStop��5	   M   $��23��6   $��Right=�6   $��
0,0,310,10q�69   $��Bottom=�6[   $��57��6v   $��SemiBold"�6�   .��6�   Stop6�   �� 5
   
   -   5        $��tcMain��5
   '   $��10,7,0,0q�6   $
��Left=�65   $	��351��6P   $	��393��6\   $	��Top=�6i   .@�5      �� -   5        $��tabPage1��5      $��Input��6&    �� 
IsSelected$
 True��65   .��5      � .+�5      �� -   5        $��label23��5   V   $��27��6   $
��Left=�6(   $��	10,14,0,0q�6C   $	��Top=�6e   $	��120��6}   $��Video input device��6�   6�   �� 5      -	   5        $��cbVideoInputDevice��5   >   $��23��6   $��	10,37,0,0q�6+   $	��Top=�6X   $
��Left=�6p   $	��233��6�   6�   �� 5      -
   5        $"��btVideoCaptureDeviceSettings��5   X   $��23��6   $
��Left=�6)   $��
251,37,0,0q�6D   $	��Top=�6|   $��75��6�   .��6�   
Settings6�   �� 5      $��30��6   $
��Left=�6(   $��	10,61,0,0q�6C   $	��Top=�6V   $	��120��6n   $��Video input format��6z   6�   �� 5      -   5        $��cbVideoInputFormat��5   >   $��23��6   $��	10,86,0,0q�6+   $	��Top=�6X   $
��Left=�6�   $	��233��6�   �� 5      -   5        $��cbUseBestVideoInputFormat��5   ?   $��16��6   $��
179,66,0,0q�6+   $	��Top=�6`   $
��Left=�6�   $��62��6�   .��6�   
Use best6�   �� 5      -   5        $��cbFramerate��5   Z   $��23��6   $
��Left=�6+   $��
251,86,0,0q�6F   $	��Top=�6m   $��75��6�   �� 5      -   5        $��label15��5   K   $
��Left=�6   $��
10,180,0,0q�67   $	��120��6Z   $��27��6f   $	��Top=�6r   .��6�   Audio output device6�   �� 5      -   5        $��cbAudioOutputDevice��5   ?   $��24��6   $��
10,204,0,0q�6+   $	��Top=�6Z   $
��Left=�6r   $	��316��6�   �� 5      -   5        $��label1��5   W   $��28��6   $
��Left=�6(   $��
16,234,0,0q�6C   $	��Top=�6e   $��59��6}   .��6�   Volume6�   �� 5      -   5        $��label2��5   =   $��28��6   $��170,234,0,0q�6(   $	��Top=�6K   $
��Left=�6c   $��59��6~   .��6�   	Balance6�   �� 5      -   5        $��tbAudioVolume��5   X   $��27��6   $��
69,237,0,0q�6)    � Maximum$	 100Q�6=    � Minimum$ 20Q�6K    � Value$ 80Q�6m   $	��Top=�6x   $
��Left=�6�   $��73��6�   6�   �� 5      -   5        $��tbAudioBalance��5   v   $��29��6   $
��Left=�6)   $��224,237,0,0q�6D   $	 100Q�6Y   $
 -100Q�6g   $	��Top=�6�   $��86��6�   6�   �� 5      -   5        $��	groupBox2��5   Q   $��Controls��6   $��97��61   $��
10,258,0,0q�6=   $	��Top=�6b   $
��Left=�6z   $	��316��6�   .��5      � .+�5      �� -   5        $��
btDVRewind��5   7   $��11,9,0,0q�6%   $��22.723��6I   $
��Left=�6Y   $	��Top=�6t   $��52��6�   .��6�   Rewind6�   �� 5      -   5        $��	btDVPause��5   8   $��	129,9,0,0q�6%   $��22.723��6I   $	��Top=�6Y   $
��Left=�6q   $��54��6�   .��6�   Pause6�   �� 5      -   5        $��btDVPlay��5   R   $
��Left=�6%   $��70,9,0,0q�6@   $��52��6b   $��22.723��6m   $	��Top=�6}   .��6�   Play6�   �� 5      -   5        $��btDVStop��5   S   $
��Left=�6%   $��	189,9,0,0q�6@   $��53��6c   $��22.723��6n   $	��Top=�6~   .��6�   Stop6�   �� 5       -   5        $��btDVFF��5    S   $
��Left=�6%   $��	248,9,0,0q�6@   $��45��6a   $��22.723��6l   $	��Top=�6|   .��6�   F.F.6�   �� 5!      -   5        $��btDVStepRev��5!   S   $
��Left=�6%   $��	33,42,0,0q�6@   $��62��6f   $��22.723��6q   $	��Top=�6�   .��6�   
Step REV6�   �� 5"      -   5        $��btDVStepFWD��5"   T   $
��Left=�6%   $��
209,42,0,0q�6@   $��62��6g   $��22.723��6r   $	��Top=�6�   .��6�   
Step FWD6�   5#      5$      �� 5%      -   5        $��	groupBox1��5%   S   $��
Resolution��6   $��65��63   $��
10,115,0,0q�6?   $	��Top=�6d   $
��Left=�6|   $	��316��6�   .��5&      � .+�5'      	� -   5        $��rbDVResFull��5'   i   $
��Left=�6*   $
 TrueY�6E   $��	12,12,0,0q�6V   $��42��6|   $	��Top=�6�   .��6�   Full6�   	� 5(      -   5        $��rbDVResQuarter��5(   Y   $
��Left=�6*   $��
167,12,0,0q�6E   $��62��6o   $��19��6z   $	��Top=�6�   .��6�   	Quarter6�   	� 5)      -   5        $��rbDVResHalf��5)   X   $
��Left=�6*   $��	90,12,0,0q�6E   $��45��6k   $	��Top=�6v   .��6�   Half6�   	� 5*      -    5        $��	rbDVResDC��5*   X   $
��Left=�6*   $��	248,9,0,0q�6E   $��38��6i   $��19��6t   $	��Top=�6�   .��6�   DC6�   5+      5,      �� 5-      -!   5        $��label3��5-   W   $��24��6   $
��Left=�6(   $��
249,61,0,0q�6C   $	��Top=�6e   $��84��6}   .��6�   
Frame rate6�   5.      5/      �� 50      $
 True��6   $��Output��6(   .��51      � .+�52      �� $��Format��6   $��23��6-   $
��Left=�69   $��	10,10,0,0q�6T   $	��Top=�6g   $��51��6   �� 53      -"   5         ��Name$ cbOutputFormat��53   >   $��23��6   $��	10,33,0,0q�6+   $	��Top=�6V   $
��Left=�6n   $	��323��6�   .@�54      �� $	��AVI��6'   �� 55      $��MKV (Matroska)��6'   �� 56      $��WMV (Windows Media Video)��6'   �� 57      $��DV��6'   �� 58      $��DV (Without reencoding)��6'   �� 59      $
��WebM��6'   �� 5:      $��FFMPEG (DLL)��6'   �� 5;      $��FFMPEG (EXE)��6'   �� 5<      $��
MP4 v8/v10��6'   �� 5=      $��MP4 v11��6'   �� 5>      $��Animated GIF��6'   �� 5?      $��Encrypted video��6'   �� 5@      $��MPEG-TS��6'   �� 5A      $	��MOV��6'   5B      �� 5C      -#   5         ��Name$ cbRecordAudio��5C   q   $��Record audio��6   $��16��66   $
��Left=�6B   $��
10,127,0,0q�6]   $	��Top=�6�   $	��109��6�   �� 5D      -$   5        	 ��Name$	 label22��5D   k   $��	File name��6   $��23��60   $
��Left=�6<   $��
10,148,0,0q�6W   $	��Top=�6|   $��62��6�   �� 5E      -%   5        
 ��Name$
 edOutput��5E   Y   $��23��6   $
��Left=�6*   $��
10,176,0,0q�6E   $	��Top=�6k   $	��294��6�   $��c:\capture.avi��6�   �� 5F      -&   5         ��Name$ btSelectOutput��5F   g   $	��...��6   $��23��6+   $��Right=�67   $��
0,176,10,0q�6S   $	��Top=�6   $��24��6�   6�   �� 5G      -'   5        $ btOutputConfigure��5G      $��	Configure��68   $
��Left=�6L   $��	10,92,0,0q�6g   $	��Top=�6z   $��75��6�   6�   �� 5H      $=��7You can use dialog or code to configure format settings��6   $
��Left=�6^   $��	10,61,0,0q�6y   $	��Top=�6�   5I      5J      �� 5K      $��Video effects��6   $
 True��6-   .��5L      � .+�5M      �� -(   5         ��Name$ lbLogos��5M      $
��Left=�6/   $	��102��6J   $	��Top=�6W   $	��325��6o   $��	10,36,0,0q�6{   �� 5N      -)   5        $ btImageLogoAdd��5N      $��Add image logo��65   $
��Left=�6N   $��
10,145,0,0q�6i   $	��Top=�6}   $��95��6�   6�   �� 5O      -*   5        $ btTextLogoAdd��5O      $��Add text logo��64   $
��Left=�6L   $��110,145,0,0q�6g   $	��Top=�6|   $��90��6�   6�   �� 5P      -+   5        $ 
btLogoEdit��5P      $
��Edit��61   $
��Left=�6@   $��230,145,0,0q�6[   $	��Top=�6p   $��50��6�   6�   �� 5Q      -,   5        $ btLogoRemove��5Q      $��Remove��63   $
��Left=�6D   $��285,145,0,0q�6_   $	��Top=�6t   $��50��6�   6�   �� 5R      --   5        $	 label��5R      $��Image / text logos��6+   $
��Left=�6H   $��	10,10,0,0q�6c   $	��Top=�6v   �� 5S      -.   5         ��Name$ tbLightness��5S   f   $��23��6   $
��Left=�6)   $��
46,205,0,0q�6D   $	 255Q�6X   $	��Top=�6{   $	��100��6�   6�   �� 5T      -/   5        $	 label92��5T   _   $��	Lightness��6   $
��Left=�60   $��
71,178,0,0q�6K   $��86��6p   $��28��6{   $	��Top=�6�   �� 5U      -0   5        $ tbSaturation��5U   g   $��23��6   $
��Left=�6)   $��214,205,0,0q�6D   $	 255Q�6Y   $	��Top=�6}   $	��100��6�   $	 255Q�6�   6�   �� 5V      -1   5        $	 label93��5V   a   $��
Saturation��6   $
��Left=�61   $��237,178,0,0q�6L   $��86��6r   $��28��6}   $	��Top=�6�   �� 5W      -2   5        $ 
tbContrast��5W   f   $��23��6   $
��Left=�6)   $��
46,271,0,0q�6D   $	 255Q�6X   $	��Top=�6z   $	��100��6�   6�   �� 5X      -3   5        $	 label94��5X   j   $��Contrast��6   $��28��6/   $
��Left=�6;   $��
67,244,0,0q�6V   $	��Top=�6{   $��60��6�   �� 5Y      -4   5        $ 
tbDarkness��5Y   g   $��23��6   $
��Left=�6)   $��214,271,0,0q�6D   $	 255Q�6Y   $	��Top=�6{   $	��100��6�   6�   �� 5Z      -5   5        $	 label95��5Z   k   $��Darkness��6   $��28��6/   $
��Left=�6;   $��237,244,0,0q�6V   $	��Top=�6|   $��86��6�   �� 5[      -6   5        $ cbGreyscale��5[   n   $��	Grayscale��6   $��16��63   $
��Left=�6?   $��
10,316,0,0q�6Z   $	��Top=�6�   6�   �� 5\      -7   5        $ cbInvert��5\   k   $��Invert��6   $��16��60   $
��Left=�6<   $��
86,316,0,0q�6W   $	��Top=�6}   6�   �� 5]      -8   5        $ cbFlipX��5]      $��Flip X��60   $
��Left=�6A   $��145,316,0,0q�6\   $	��Top=�6q   6�   �� 5^      -9   5        $ cbFlipY��5^      $��Flip Y��60   $
��Left=�6A   $��200,316,0,0q�6\   $	��Top=�6q   6�   �� 5_      -:   5        $ cbDeinterlaceCAVT��5_      $��Deinterlace��6:   $
��Left=�6P   $��255,316,0,0q�6k   $	��Top=�6�   $
 TrueY�6�   �� 5`      -;   5        $	 label4��5`      $6��0More effects and settings available in Main Demo��6,   $
��Left=�6g   $��
46,336,0,0q�6�   $	��Top=�6�   5a      5b      �� 5c      $	��Log��6   $
 True��6#   .��5d      � .+�5e      �� -<   5        $��mmLog��5e   1   $��	10,31,0,0q�6    �� TextWrapping$
 Wrap=�6>   $
��Left=�6R   $	��Top=�6m   $	��324��6�   $	��323��6�   �� 5f      -=   5        $��cbDebugMode��5f   X   $��16��6   $
��Left=�6+   $��9,10,0,0q�6F   $	��Top=�6k   $��93��6�   .��6�   
Debug Mode6�   �� 5g      ->   5        $ cbLicensing��5g      $��Licensing info��64   $
��Left=�6M   $��
126,10,0,0q�6h   $	��Top=�6|   5h      5i      5j      �� 5k   
   -?   5        $��label25��5k   5   $��Video tutorial��6   $��28��6)   $	��Top=�6D   $
��Bold"�6\   ���	#FF0024BE$��Right=�6�   $��91��6�   $��0,0,10,0q�6�   -   'VisioForge.Controls.UI.WPF.VideoCapture  5l   
   -@   5        $��VideoCapture1��5l   0   $��377,26,10,75q�6   
���   �5m   :   �� 5n   
   -A   5         ��Name$ lbTimestamp��5n      $��Right=�6)   $��	0,0,74,39q�6E   $
��Wrap=�6X   $��Recording time: 00:00:00��6l   $��Bottom=�6�   �� 5o   
   -B   5        $ btResume��5o   ^   $��Resume��6   $��23��6"   $��Right=�6.   $��
0,0,147,10q�6J   $��Bottom=�6p   $��58��6�   6�   �� 5p   
   -C   5        $ btPause��5p   ]   $��Pause��6   $��23��6!   $��Right=�6-   $��
0,0,210,10q�6I   $��Bottom=�6n   $��62��6�   6�   �� 5q   
   -D   5        $ btSaveScreenshot_Copy��5q   �   $��Save screenshot��6   $��23��6+   $��Right=�67    �� 	IsDefault$ False��6S   $
{�True��6e   $��	0,0,10,10q�6v   $��Bottom=�6�   $	��118��6�   6�   �� 5r   
   $/��)Much more features available in Main Demo��6   $��Right=�6D   $��	0,0,123,0q�6`   $	��Top=�6s   5s      5t      