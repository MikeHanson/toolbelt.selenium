using System;
using System.Configuration;
using OpenQA.Selenium;

namespace Toolbelt.Selenium.Configuration
{
    public class ProxyConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("ftpProxy")]
        public string FtpProxy
        {
            get { return (string)this["ftpProxy"]; }
            set { this["ftpProxy"] = value; }
        }

        [ConfigurationProperty("httpProxy")]
        public string HttpProxy
        {
            get { return (string)this["httpProxy"]; }
            set { this["httpProxy"] = value; }
        }

        [ConfigurationProperty("isAutoDetect")]
        public bool IsAutoDetect
        {
            get { return (bool)this["isAutoDetect"]; }
            set { this["isAutoDetect"] = value; }
        }

        [ConfigurationProperty("kind")]
        public ProxyKind Kind
        {
            get { return (ProxyKind)this["kind"]; }
            set { this["kind"] = value; }
        }

        [ConfigurationProperty("noProxy")]
        public string NoProxy
        {
            get { return (string)this["noProxy"]; }
            set { this["noProxy"] = value; }
        }

        [ConfigurationProperty("proxyAutoConfigUrl")]
        public string ProxyAutoConfigUrl
        {
            get { return (string)this["proxyAutoConfigUrl"]; }
            set { this["proxyAutoConfigUrl"] = value; }
        }

        [ConfigurationProperty("socksPassword")]
        public string SocksPassword
        {
            get { return (string)this["socksPassword"]; }
            set { this["socksPassword"] = value; }
        }

        [ConfigurationProperty("socksProxy")]
        public string SocksProxy
        {
            get { return (string)this["socksProxy"]; }
            set { this["socksProxy"] = value; }
        }

        [ConfigurationProperty("socksUserName")]
        public string SocksUserName
        {
            get { return (string)this["socksUserName"]; }
            set { this["socksUserName"] = value; }
        }

        [ConfigurationProperty("sslProxy")]
        public string SslProxy
        {
            get { return (string)this["sslProxy"]; }
            set { this["sslProxy"] = value; }
        }

        public Proxy ToProxy()
        {
            var result = new Proxy
                         {
                             FtpProxy = this.FtpProxy,
                             HttpProxy = this.HttpProxy,
                             IsAutoDetect = this.IsAutoDetect,
                             Kind = this.Kind,
                             NoProxy = this.NoProxy,
                             ProxyAutoConfigUrl = this.ProxyAutoConfigUrl,
                             SocksPassword = this.SocksPassword,
                             SocksProxy = this.SocksProxy,
                             SocksUserName = this.SocksUserName,
                             SslProxy = this.SslProxy
                         };

            return result;
        }
    }
}