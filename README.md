# Unittest entity mapping using JSON and ApprovalTests

POC to unittest mappings between entities using JSON and ApprovalTests with a single line of code:

```
Approvals.Verify(TestJson.SerializeForApprovals(mappedEntity));
```

ApprovalTests will generate a file containing the JSON representation of the mappedEntity. You manually approve the 'json file' and you have tested the whole mapping.

The original codebase of ValueInjector has many tests with lines as:

```
Assert.That(mappedEntity.Name, Is.EqualTo("Michael Jackson"));
Assert.That(mappedEntity.Age, Is.EqualTo(42));
```

## Libraries used
* [Json.Net](https://www.nuget.org/packages/Newtonsoft.Json/)
* [NUnit](https://www.nuget.org/packages/NUnit/) 
* [ApprovalTests](https://www.nuget.org/packages/ApprovalTests/) simplifies the creation of unittest by taking a snapshot of the results, and confirming that they have not changed.
* [ValueInjecter](https://www.nuget.org/packages/ValueInjecter/) is a mapper. It can be used for mapping Dto to Entity and back also for mapping IDataReader to objects, windows forms to object, etc. Also has support for flattening and unflattening.