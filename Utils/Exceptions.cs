namespace MatrixDigital;

// Custom exceptions for invalid user input errors:

public class InvalidFormatException : Exception
{
    public InvalidFormatException() : base ("Error! Input was recieved in an invalid format.") { }
}

public class NotUniqueException : Exception
{
    public NotUniqueException() : base ("Error! Input field must be unique.") { }
}

public class NotANumberException : Exception
{
    public NotANumberException() : base ("Error! Input must be of numeric type.") { }
}

public class InvalidRangeException : Exception
{
    public InvalidRangeException(double min, double max) : base ($"Error! Value must be between {min} and {max}.") { }

    public InvalidRangeException(double min) : base ($"Error! Value must be at least {min} characters long.") { }
}

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(string id) : base ($"Error! Resource with the id of {id} was not found.") { }
}

public class InvalidResourceTypeException : Exception
{
    public InvalidResourceTypeException(string type) : base($"Error! Resource is not of type '{type}'.") { }
}
