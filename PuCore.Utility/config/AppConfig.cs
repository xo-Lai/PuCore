using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuCore.Utility.config
{
 public    class AppConfig
    {
        /// <summary>
        /// mysql 数据库连接
        /// </summary>
        public static string MySqlConnection { get; } = ConfigurationManager.Configuration.GetConnectionString("MySqlConnection");

    }
}
