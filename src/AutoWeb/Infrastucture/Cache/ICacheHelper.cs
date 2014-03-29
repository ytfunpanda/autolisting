using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public interface ICacheHelper
{
    void Add(string keyName, object value, DateTime expiration);
    void Add(string keyName, object value);
    object Get(string keyName);
    bool Remove(string keyName);
}