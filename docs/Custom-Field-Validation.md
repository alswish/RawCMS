To manage *Entity Validation* there are many FieldValidator used to check if a field value is valid for such schema definition.

Standard validator are shipped with RawCMS:

* Number
* Integer
* DateTime
* Text

you can add you own type, just implement the class:

```cs
    public class MyTypeValidator: FieldTypeValidator
    {
        public string Type =>"MyTypeValidator";
        public  List<Error> Validate(JObject input, Field field)
        {
           // DO CHECK HERE
        }
    }
```

the value of *Type*  match with field type in schema validation