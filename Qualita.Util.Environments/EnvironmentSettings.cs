using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Qualita.Util.Environments
{
    [ExcludeFromCodeCoverage]
    public class EnvironmentSettings
    {
        private static readonly EnvironmentSettingsSection _envSection =
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                                .GetSection("environmentSettings") as EnvironmentSettingsSection;

        /// <summary>
        /// Obtém/Altera qual confguração está em uso
        /// </summary>
        public static string UseEnvironKey
        {
            get => _envSection.UseEnvironKey;
            set => _envSection.UseEnvironKey = value;
        }

        /// <summary>
        /// Quantidade de environments configurado
        /// </summary>
        public static int Count => _envSection.Environments.Count;

        /// <summary>
        /// Retorna o caminho do arquivo externo de configuração está sendo utilizado
        /// </summary>
        public static string File => _envSection.Environments[_envSection.UseEnvironKey].FileName;

        /// <summary>
        /// Devolve o valor da chave desejada, para o ambiente ativo.
        /// </summary>
        /// <param name="settingKey">Chave de configuração</param>
        /// <returns>string</returns>
        public static string Setting(string settingKey)
        {
            return Setting(settingKey, _envSection.UseEnvironKey);
        }

        /// <summary>
        /// Devolve o valor da chave desejada, para o ambiente indicado.
        /// </summary>
        /// <param name="settingKey">Chave de configuração</param>
        /// <param name="environKey">Ambiente configurado</param>
        /// <returns>string</returns>
        public static string Setting(string settingKey, string environKey)
        {
            return _envSection.Environments[environKey].Settings[settingKey].Value;
        }

        public static string Setting(string settingKey, int environIndex)
        {
            return _envSection.Environments[environIndex].Settings[settingKey].Value;
        }


        /// <summary>
        /// Devolve o dicionario de chave/valor das configurações existentes no ambiente ativo
        /// </summary>
        /// <returns>Dictionary<string, string></returns>
        public static Dictionary<string, string> Settings()
        {
            return Settings(_envSection.UseEnvironKey);
        }


        /// <summary>
        /// Devolve o dicionario de chave/valor das configurações existentes no ambiente indicado
        /// </summary>
        /// <param name="environKey">Ambiente configurado</param>
        /// <returns>Dictionary<string, string></returns>
        /// <exception cref="Exception">environKey não definida</exception>
        public static Dictionary<string, string> Settings(string environKey)
        {
            var environ = _envSection.Environments[environKey];

            if (environ == null)
                throw new Exception($"A environ '{environKey}' não foi definida.");


            var settings = new Dictionary<string, string>();
            foreach (Elements.SettingElement item in environ.Settings)
            {
                settings.Add(item.Key, item.Value);
            }

            return settings;
        }

        public static Dictionary<string, string> Settings(int environIndex)
        {
            var environ = _envSection.Environments[environIndex];

            if (environ == null)
                throw new Exception($"A environ na posição '{environIndex}' não foi definida.");


            var settings = new Dictionary<string, string>();
            foreach (Elements.SettingElement item in environ.Settings)
            {
                settings.Add(item.Key, item.Value);
            }

            return settings;
        }

    }
}
