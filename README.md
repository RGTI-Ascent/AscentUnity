# AscentUnity
SMRT - playerScript ma "gameStarted" variable ki vklopi/izklopi input. Ob smrti lahko nastavis na false in enablas DEATH MENU + kamera zoom out po zelji (spremenis heightOffset, towerRadious in smoothing v Camera.cs, kamera avtomatsko smoothly zooma na novo lokacijo) da implementiras smrt, treba je se dodat funkcionalnost gumbu, najlazje samo reload scene in gres nazaj na zacetni state. Podobno za END MENU.

PLAYER - oddaljenost od stolpa se spremeni s spreminjanjem Z komponente od "playerSprite" objekta. Level se zacne pri pesku in najboljse da se da nek trigger na stopnice ki potem postavi playerja na travo (in zmanjsa njegovo z komponento). Treba je tudi izklopit box collider od "Base" objekta v levelu ko je player na pesku pa ga pol enablat ko pride na travo, drugac bo padu skoz tla

LEVEL - se gradi z copy pastanjem ze narjenih platform 
