**Récupére les données !**

Les données ont été dissimulées sur le réseau.

Notre intrusion risque d'être remarquée.

Récupère le plus de fichiers avant d'être repéré.


Il te reste 1h (3600s) avant que nous soyons détectés.

Tu peux naviguer de serveur en serveur et de là, récupérer les fichiers présents dessus.

Tous les 10 fichiers transférés, tu te déconnectes pour rester discret et repars du serveur d'origine.

Te connecter d'un serveur à l'autre te prend quelques secondes, le transfert est immédiat.


En entrée : 2499 lignes décrivant les fichiers présents sur chaque serveur.

Sur chaque ligne, un nombre : l'id du serveur, puis séparés par des espaces les ids des fichiers.

Ensuite 20000 lignes décrivant les liens entre les serveurs.

Les liens fonctionnent dans les deux sens.

Sur chaque ligne, l'identité des deux serveurs et le temps en secondes de connexion séparés par des espaces.

Le résultat attendu : une suite de nombres séparés par des espaces, correspondant à tes actions.

si le nombre correspond à un id de serveur, tu te connectes vers ce serveur (il doit exister un lien entre ta position et ce serveur).
si le nombre correspond à un id de fichier, tu récupères ce fichier (il doit être présent à ta position) (s'il a déjà été récupéré, l'instruction est ignorée).
si c'est 0, tu te déconnectes et te reconnectes sur le serveur d'origine avec l'id 0, cela remet à 0 également le compteur des 10 fichiers avant reconnexion.
Toute action illicite entraine une déconnexion/reconnexion

1 point par fichier unique récupéré ! Un fichier peut exister sur plusieurs serveurs, mais ne peut être récupéré qu'une fois.

Exemple

1453 10160 116 10112
  On se connecte sur le serveur 1453 où l'on télécharge le fichier 10160, puis on se connecte deouis le 1453 vers le 116, et l'on y récupère le fichier 10112