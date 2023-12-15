using Lab7;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;

//Cow cow = new Cow();
//Lion lion = new Lion();
//Pig pig = new Pig();

//Animal animal = new Animal();

//XmlSerializer serializer = new XmlSerializer(typeof(Animal));
//using (FileStream fs = new FileStream("Animal.xml", FileMode.OpenOrCreate)) 
//{
//    serializer.Serialize(fs, animal);
//    serializer.Serialize(fs, cow);
//    serializer.Serialize(fs, pig);
//    serializer.Serialize(fs, lion);
//}

var asm = Assembly.GetAssembly(typeof(Animal));
var XDoc = new XDocument(new XElement("Classes"));

foreach(var type in asm.GetTypes().Where(m => m.IsClass))
{
    var XClass = new XElement("Class", new XAttribute("Name", type.Name));
    var comment = type.GetCustomAttribute<CustomCommentAttribute>();

    if(comment != null)
    {
        XClass.Add(new XElement("Comment", comment.Comment));
    }

    var props = type.GetProperties();

    foreach (var prop in props) 
    {
        var XProp = new XElement("Property");
        XProp.Add(new XAttribute("Name", prop.Name));
        XProp.Add(new XAttribute("Type", prop.PropertyType.Name));
        XClass.Add(XProp);
    }

    var constrs = type.GetConstructors();

    foreach (var constr in constrs)
    {
        var XConstr = new XElement("Constructor");
        XConstr.Add(new XAttribute("Name", constr.Name));
        XClass.Add(XConstr);
    }

    var methods = type.GetMethods();

    foreach (var method in methods)
    {
        var XMethod = new XElement("Method");
        XMethod.Add(new XAttribute("Name", method.Name));
        XMethod.Add(new XAttribute("ReturnType", method.ReturnType.Name));
        XClass.Add(XMethod);
    }

    XDoc.Root.Add(XClass);
}

XDoc.Save("Animals.xml");
