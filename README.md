# Course De Lapin
## Présentation 
Le but de ce TP est de réaliser une application Windows Form en C# permettant la gestion de courses de lapins, des lapins et l'assignation de lapin aux courses.

## Application : 

Deux possibilités s'offre à nous
![app](https://image.noelshack.com/fichiers/2020/49/3/1606917614-appli.png)

### La gestion des courses : 
![gestioncourses](https://image.noelshack.com/fichiers/2020/49/3/1606917733-capture3.png)

Avec la possibilité d'ajouter des courses en choisissant la distance (l'id sera automatiquement ajouter lors de l'insertion dans la Db: 
![creacourse](https://image.noelshack.com/fichiers/2020/49/3/1606917841-capture4.png)

Nous pouvons ensuite les ajouter ou les supprimer de la base de donnée en sauvegardant(Save)
Il y a différents status : 
 
Changed : Modification sur l'application mais pas sur la DB
Unchanged : Modification effectués sur la DB

### La gestion des lapins : 
Ici s'affiche les courses et les lapins qui y participe
![creacourse](https://image.noelshack.com/fichiers/2020/49/3/1606918146-capture2.png)

Avec la possibilité d'ajouter ou supprimer des lapins des courses en renseignant : 
- Le nom
- l'age
- le dossard

![editcourse](https://image.noelshack.com/fichiers/2020/49/3/1606918278-capture.png)

