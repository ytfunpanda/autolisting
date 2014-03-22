using System.Web.Script.Serialization;

public static class JSONExtensions {
    public static string ToJson(this object obj) {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        
        return serializer.Serialize(obj);
    }
}
