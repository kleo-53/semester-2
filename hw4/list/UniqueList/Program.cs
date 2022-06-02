using UniqueList;

var list = new UniqueList.UniqueList();
list.Add(421);
list.Add(2);
list.Add(3);
list.Add(4, 1);
list.Contains(421);
list.Add(421, 1);
list.Add(421);