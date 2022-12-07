using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CsvUtils
    {
        public static readonly Char[] columnSeparators = new Char[] { ',', ';', '.' };

        public static DataTable ReadCsvAsDataTable(string filePath)
        {
            // Vérifier si le fichier existe
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Le fichier spécifié n'existe pas.");
            }

            // Créer un nouveau DataTable pour stocker les données du fichier CSV
            var csvData = new DataTable();

            // Utiliser un StreamReader pour lire le fichier ligne par ligne
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Lire la première ligne pour obtenir les noms de colonnes
                string[] columnNames = reader.ReadLine().Split(columnSeparators);

                // Ajouter les colonnes au DataTable
                foreach (string columnName in columnNames)
                {
                    csvData.Columns.Add(columnName);
                }

                // Lire les lignes suivantes pour obtenir les données
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Diviser chaque ligne en colonnes en utilisant le séparateur spécifié
                    string[] columns = line.Split(columnSeparators);

                    // Ajouter une nouvelle ligne au DataTable
                    csvData.Rows.Add(columns);
                }
            }

            // Renvoyer le DataTable construit
            return csvData;
        }
    }
}
