# ViewModel

Some tiny and useful well known base classes for building ViewModels at any .NET Standard >= 1.6 project.

## [BindableBase](./src/BindableBase.cs)

A well known basic class that implements `INotifyPropertyChanged`.

[See a working example](./test/BindableBaseTest.cs)


## [ComputedBindableBase](./src/ComputedBindableBase.cs) + [PropertySourceAttribute](./src/PropertySourceAttribute.cs)

Based on `BindableBase`, add a useful way to manage dependencies between observable properties.

You can add the attribute `PropertySource` over a property that depends of another one, and it will automatically notify all the transitive changes.

[See a working example](./test/ComputedBindableBaseTest.cs)