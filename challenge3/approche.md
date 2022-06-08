Pour l'exercice 3 j'ai eu une approche "brut force" c’est-à-dire essayer toutes les combinaisons possibles.

Mais 25000 valeurs cela veut dire beaucoup trop de boucles (25000*24999*24998 = 15*10^12)

Après observation des valeurs je me rends compte que pas mal de combinaisons ont une valeur inférieure à 987654321, ce qui permet d'abandonner la boucle car la somme sera toujours inférieure à 987654321.

Je charge l'ensemble des valeurs en mémoire et je cherche la valeur maximale max. Quand la somme de deux valeur + max est inférieur au code recherché alors j'abandonne la boucle car aucune combinaison ne fonctionnera.

Je lance mes boucles en parallèle avec "Parallel.For" qui va s’ajuster automatiquement au nombre de cœurs logiques de mon processeur. Sur ma machine AMD Ryzen 7 avec 16 cœurs logiques cela donne 24 threads. Lors de l’exécution je suis bien à 100% CPU.

Les premiers microprocesseurs ne pouvaient effectuer qu’un seul calcul à la fois. Maintenant les microprocesseurs possèdent plusieurs unités de calcul. Un système d'exploitation propose des outils pour exploiter ces unités de calcul, comme les Thread que j'utilise ici.

Je trouve la réponse en 10 minutes. Attention de ne pas lancer le calcul en mode debug depuis Visual Studio, ce dernier ralentissant énormément l’ensemble car il reprend la main en tâche de fond pour suivre les threads.

````
--- Challenge3 (long)
08/06/2022 06:08:59
Max = 930086315
a = 3008582 b = 930086315 c = 54559424
a * b * c = 152670414213626049729920
a * b * c % 987654321 = 138688076
08/06/2022 06:18:34
````