**Trouve le mot de passe !**

Il te faut un mot de passe pour te connecter sur la machine du voleur.

Par chance, le mot de passe a �t� g�n�r� par un g�n�rateur maison dont nous avons compris le fonctionnement.

Il utilise une suite de nombres comme source al�atoire, il cherche ensuite dans cette liste, un triplet a, b, c, tel que :

a+b+c = 987654321
Le mot de passe est ensuite :

a * b * c % 987654321 (modulo)

La suite des nombres al�atoires a �t� d�voil�e, elle constitue ton input.


En entr�e : une liste de nombres, un par ligne.

Le r�sultat attendu : le mot de passe recherch�.

500 points pour la bonne r�ponse !