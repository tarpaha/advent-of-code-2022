namespace day_2022_12_03;

public record Item(char Type);
public record Rucksack(IEnumerable<Item> Items);
public record Data(IEnumerable<Rucksack> Rucksacks);