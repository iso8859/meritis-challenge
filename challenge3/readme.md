**Trouve le mot de passe !**

Il te faut un mot de passe pour te connecter sur la machine du voleur.

Par chance, le mot de passe a été généré par un générateur maison dont nous avons compris le fonctionnement.

Il utilise une suite de nombres comme source aléatoire, il cherche ensuite dans cette liste, un triplet a, b, c, tel que :

a+b+c = 987654321
Le mot de passe est ensuite :

a * b * c % 987654321 (modulo)

La suite des nombres aléatoires a été dévoilée, elle constitue ton input.


En entrée : une liste de nombres, un par ligne.

Le résultat attendu : le mot de passe recherché.

500 points pour la bonne réponse !