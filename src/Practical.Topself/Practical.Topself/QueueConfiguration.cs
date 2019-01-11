using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical.Topself
{
    public class QueueConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("hostName")]
        public string HostName
        {
            get
            {
                return (string)this["hostName"];
            }
            set
            {
                this["hostName"] = value;
            }
        }

        [ConfigurationProperty("userName")]
        public string UserName
        {
            get
            {
                return (string)this["userName"];
            }
            set
            {
                this["userName"] = value;
            }
        }

        [ConfigurationProperty("password")]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }

        [ConfigurationProperty("queueName")]
        public string QueueName
        {
            get
            {
                return (string)this["queueName"];
            }
            set
            {
                this["queueName"] = value;
            }
        }
    }
}
