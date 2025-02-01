namespace System;

public static class ObjectExtension
{
    public static bool IsObjectNullOrEmpty<T>(this T? obj)
    {
        return (obj == null);
    }
    public static bool IsNullOrEmpty(this IEnumerable<object> objects)
    {
        return objects == null || !objects.Any();
    }
    public static bool IsNullOrEmpty(this ICollection<object> objects)
    {
        return objects == null || !objects.Any();
    }
}