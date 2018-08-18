using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgUpload
{
    /// <summary>
    /// Allow to get the whole app in English or French
    /// </summary>

    public static class Translations
    {
        private static Dictionary<string, string> translations;

        /// <summary>
        /// Return a tranlation for the requested text
        /// </summary>
        /// <param name="msg_name">text identifier</param>
        /// <returns>returns translation for this identifier</returns>

        public static string Get(string msg_name)
        {
            if (translations == null)
                init_messages();

            if (translations.ContainsKey(msg_name))
                return translations[msg_name];

            return msg_name.ToUpper();
        }

        /// <summary>
        /// Initialize translations to French or English depending on system language
        /// </summary>

        private static void init_messages()
        {
            translations = new Dictionary<string, string>();
            
            if (System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName == "fra")
            {
                translations["imgsize_resample"] = "Ne pas redimensionner";
                translations["imgsize_1600x1600"] = "1600x1200 (écran 21 pouces)";
                translations["imgsize_1280x1280"] = "1280x1024 (écran 19 pouces)";
                translations["imgsize_1024x1024"] = "1024x768 (écran 17 pouces)";
                translations["imgsize_800x800"] = "800x600 (écran 15 pouces)";
                translations["imgsize_640x640"] = "640x480 (destiné à des forum)";
                translations["imgsize_320x320"] = "320x240 (destiné à des sites web et des emails)";
                translations["imgsize_150x150"] = "150x112 (miniature ou vignette d'image)";
                translations["imgsize_100x100"] = "100x75 (avatar)";

                translations["button_select"] = "Envoyer une image";
                translations["button_cancel"] = "Annuler";
                translations["button_close"] = "Fermer";
                translations["button_browse"] = "Parcourir...";

                translations["error"] = "Erreur";
                translations["error_no_image"] = "Veuillez d'abord choisir une image en cliquant sur Parcourir";
                translations["error_invalid_filetype"] = "Seuls les fichiers jpeg, png, bitmap, gif et tiff sont acceptés.";
                translations["error_file_not_found"] = "Impossible de trouver le fichier";
                translations["error_upload"] = "Une erreur est survenue lors de l'upload de l'image.";
                translations["error_url"] = "L'URL d'image retourné par le service d'upload est invalide.";

                translations["text_choose_picture"] = "Choisir une image";
                translations["text_image_files"] = "Fichiers images";
                translations["text_upload_in_progress"] = "Envoi en cours...";
                translations["text_resizepic"] = "Redimensionner l\'image ?";
                translations["text_result"] = "Résultat";
                translations["text_copy"] = "Copier";
                translations["text_output_format"] = "Format de sortie";
                translations["text_size_forum_fullsize"] = "Code forum + lien taille 100%";
                translations["text_size_forum"] = "Code forum";
                translations["text_size_directlink"] = "Lien direct";
                translations["text_advanced_mode"] = "Envoi d\'image avec paramètres personnalisés";
                translations["text_about_this_provider"] = "Infos";

                translations["about_about"] = "A propos de";
                translations["about_created_by"] = "Ce logiciel vous est proposé par";
                translations["about_website"] = "Site internet";
                translations["about_service_offered_by"] = "Ce service vous est offert par";
                translations["about_confirm_visit"] = "Cliquez sur OK pour visiter le site internet de cet hébergeur.";
                translations["about_title"] = "A propos...";
            }
            else
            {
                translations["imgsize_resample"] = "Do not resize";
                translations["imgsize_1600x1600"] = "1600x1200 (21-inch screen)";
                translations["imgsize_1280x1280"] = "1280x1024 (19-inch screen)";
                translations["imgsize_1024x1024"] = "1024x768 (17-inch screen)";
                translations["imgsize_800x800"] = "800x600 (15-inch screen)";
                translations["imgsize_640x640"] = "640x480 (for forums)";
                translations["imgsize_320x320"] = "320x240 (for websites and emails)";
                translations["imgsize_150x150"] = "150x112 (thumbnail or preview image)";
                translations["imgsize_100x100"] = "100x75 (avatar)";

                translations["button_select"] = "Send a picture";
                translations["button_cancel"] = "Cancel";
                translations["button_close"] = "Close";
                translations["button_browse"] = "Browse...";

                translations["error"] = "Error";
                translations["error_no_image"] = "Please first choose a picture by clicking Browse";
                translations["error_invalid_filetype"] = "Only jpeg, png, bitmap, gif and tiff files are accepted.";
                translations["error_file_not_found"] = "Cannot find the file";
                translations["error_upload"] = "An error occured during the upload process.";
                translations["error_url"] = "The upload service returned an invalide image URL.";

                translations["text_choose_picture"] = "Choose a picture";
                translations["text_image_files"] = "Image files";
                translations["text_upload_in_progress"] = "Upload in progress...";
                translations["text_resizepic"] = "Resize the picture?";
                translations["text_result"] = "Result";
                translations["text_copy"] = "Copy";
                translations["text_output_format"] = "Output format";
                translations["text_size_forum_fullsize"] = "Forum code + Full size link";
                translations["text_size_forum"] = "Forum code";
                translations["text_size_directlink"] = "Direct link";
                translations["text_advanced_mode"] = "Image sending with custom settings";
                translations["text_about_this_provider"] = "Info";

                translations["about_about"] = "About";
                translations["about_created_by"] = "This software was created by";
                translations["about_website"] = "Website";
                translations["about_service_offered_by"] = "This service is provided by";
                translations["about_confirm_visit"] = "Click OK  to visit this host's website.";
                translations["about_title"] = "About...";
            }
        }
    }
}
