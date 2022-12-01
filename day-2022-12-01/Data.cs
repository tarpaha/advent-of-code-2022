namespace day_2022_12_01;

public record Inventory(IEnumerable<int> Calories);
public record Data(IEnumerable<Inventory> Inventories);