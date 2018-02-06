# IEnumerable<T> example with Yield Return

This is an example of how to handle very large observable collections.

Below is what most folks would wnat to do in terms of transforming one ObservableCollection<T> into a larger one (say to insert records or something like that).
On a really large scale (think millions of rows), the memory usage will be duplciated between both instances of the ObservableCollection<T>.

``` csharp
    readonly ObservableCollection<Person> PersonCollection;
    ...
    public ObservableCollection<Person> AddValues(ObservableCollection<Person> oldCollection)
    {
        // Collection is duplicated here...
        var newCollection = new ObservableCollection<Person>(oldCollection);

        return newCollection;
    }

```

One could consider using yield return instead (for large values of the collection) similar to the below code.

``` csharp
    readonly ObservableCollection<Person> PersonCollection;
    ...
    public IEnumerable<Person> AddValues(ObservableCollection<Person> oldCollection)
    {
        // Collection is duplicated here...
        foreach (var item in oldCollection)
        {
            yield return item;
        }

        return newCollection;
    }

```