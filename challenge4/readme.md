**R�cup�re les donn�es !**

Les donn�es ont �t� dissimul�es sur le r�seau.

Notre intrusion risque d'�tre remarqu�e.

R�cup�re le plus de fichiers avant d'�tre rep�r�.


Il te reste 1h (3600s) avant que nous soyons d�tect�s.

Tu peux naviguer de serveur en serveur et de l�, r�cup�rer les fichiers pr�sents dessus.

Tous les 10 fichiers transf�r�s, tu te d�connectes pour rester discret et repars du serveur d'origine.

Te connecter d'un serveur � l'autre te prend quelques secondes, le transfert est imm�diat.


En entr�e : 2499 lignes d�crivant les fichiers pr�sents sur chaque serveur.

Sur chaque ligne, un nombre : l'id du serveur, puis s�par�s par des espaces les ids des fichiers.

Ensuite 20000 lignes d�crivant les liens entre les serveurs.

Les liens fonctionnent dans les deux sens.

Sur chaque ligne, l'identit� des deux serveurs et le temps en secondes de connexion s�par�s par des espaces.

Le r�sultat attendu : une suite de nombres s�par�s par des espaces, correspondant � tes actions.

si le nombre correspond � un id de serveur, tu te connectes vers ce serveur (il doit exister un lien entre ta position et ce serveur).
si le nombre correspond � un id de fichier, tu r�cup�res ce fichier (il doit �tre pr�sent � ta position) (s'il a d�j� �t� r�cup�r�, l'instruction est ignor�e).
si c'est 0, tu te d�connectes et te reconnectes sur le serveur d'origine avec l'id 0, cela remet � 0 �galement le compteur des 10 fichiers avant reconnexion.
Toute action illicite entraine une d�connexion/reconnexion

1 point par fichier unique r�cup�r� ! Un fichier peut exister sur plusieurs serveurs, mais ne peut �tre r�cup�r� qu'une fois.

Exemple

1453 10160 116 10112
  On se connecte sur le serveur 1453 o� l'on t�l�charge le fichier 10160, puis on se connecte deouis le 1453 vers le 116, et l'on y r�cup�re le fichier 10112