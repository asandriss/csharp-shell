using LanguageExt;
using LanguageExt.Common;

namespace CcShell;

public static class ValidationExt
{
    public static Validation<Error, IEnumerable<string>> Fail(string message) =>
        Validation<Error, IEnumerable<string>>.Fail(Error.New(message));

    public static Validation<Error, IEnumerable<string>> Success(IEnumerable<string> args) =>
        Validation<Error, IEnumerable<string>>.Success(args);
}