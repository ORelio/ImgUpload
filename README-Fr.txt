======================================================
==== ImgUpload v1.5.0 - Par ORelio - Microzoom.fr ====
======================================================

Merci d'avoir téléchargé ImgUpload !

Ce programme permet d'envoyer facilement des images sur différents hébergeurs d'image puis d'en récupérer le lien.
Il permet via le mode d'envoi avancé de générer des miniature et des codes d'intégration pour les forums.
Vous pouvez également ajouter ImgUpload au menu contextuel des images, voir instructions ci-dessous.

=============
 Utilisation
=============

Le programme ImgUpload.exe est portable et fonctionne sans aucun autre fichier.
Un fichier ImgUpload.cfg est généré pour se souvenir de vos préférences d'hébergeur et de redimensionnement d'image.

Après avoir lancé le programme, utilisez les boutons fléchés pour choisir un hébergeur.
En mode d'envoi simple, faites-glisser une image sur la fenêtre ou cliquez sur Envoyer une image.
En mode d'envoi avancé, sélectionnez le mode de redimensionnement désiré et le format de sortie.

=============================
 Ajout aux menus contextuels
=============================

Si vous souhaitez ajouter une option "Envoyer avec ImgUpload" dans le menu contextuel (clic droit) des images,
vous pouvez utiliser FileActionsManager https://github.com/ORelio/FileActionsManager/releases/latest :

 - Lancez ImgUpload et sélectionnez votre hébergeur préféré, puis cliquez sur Fermer
 - Lancez FileActionsManager et acceptez qu'il s'associe avec les fichiers .seinf
 - Cliquez sur ImgUpload-FR.seinf et acceptez la création de l'action
 - Lancez FileActionsManager et acceptez qu'il se désassocie des fichiers .seinf
 - Lors du clic sur "Envoyer avec ImgUpload", l'image est envoyée sur l'hébergeur choisi

Pour supprimer l'action, réouvrez ImgUpload-FR.seinf avec FileActionsManager, il vous proposera de la désinstaller.

=====
 FAQ
=====

Q: Que faire si l'un des hébergeurs ne fonctionne plus ou que je souhaite en proposer un ?
R: Créez un ticket ici : https://github.com/ORelio/ImgUpload/issues

+--------------------+
| © 2012-2018 ORelio |
+--------------------+