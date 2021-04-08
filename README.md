# ECC.NET
ECC.NET is a .NET 5 library, which implements elliptic-curve primitives (such as curves themselves, points, numeric operations, etc.). It is possible to use included curves, but also create custom ones. Library was originally developed targeting .NET Standard - this version is stil available in branch `dotnet-standard`, but will not receive updates anymore.

## Features
* included elliptic-curves
  * brainpoolp160r1, brainpoolp192r1, brainpoolp224r1, brainpoolp256r1, brainpoolp320r1, brainpoolp384r1, brainpoolp512r1
  * nistp192, nistp256, nistp384, nistp521
  * secp160r1, secp160r2, secp160k1, secp192r1, secp192k1, secp224r1, secp224k1, secp256r1, secp256k1
* elliptic-curve point operations
* operations with big numbers (Miller–Rabin primality test, cryptografic random number generator, etc.)
* independent of the target architecture
* documentation for vast majority of functions (included in code)
* simple usage

## Architecture
```
ECC.NET solution
+-- ECC.NET
|   +-- Commons.cs                              (common objects to more ECC.NET classes)
|   +-- Cryptography.cs                         (cryptographic functions using elliptic-curves)
|   +-- Curve.cs                                (ECC.NET elliptic-curve class)
|   +-- Numerics.cs                             (operations with big numbers as extensions)
|   +-- Point.cs                                (ECC.NET elliptic-curve point class)
+-- ECC.NET.Exceptions
|   +-- CurvesMismatchException.cs              (one of the points has different curve instance assigned)
|   +-- GreatestCommonDivisorException.cs       (unwanted greatest common divisor value)
|   +-- InvalidPointException.cs                (point is not on appropriate curve)
|   +-- UnknownCurveException.cs                (usage of unknown elliptic-curve name)
+-- ECC.NET.Tests
|   +-- PointOperations                         (point operations xUnit tests - test per EC)
|   |   +-- ...
|   +-- Protocols                               (test of implemented xUnit protocols - test per EC)
|   |   +-- ...
|   +-- ICurveSpecific.cs                       (interface defining EC specific class)
```

## Examples
These are some examples of basic ECC.NET usage. All examples follow each other...

### Curve instantiation (secp256r1)
```csharp
Curve curve = new Curve(Curve.Names.secp256r1);
```

### Multiplication of elliptic-curve specific point G by random number
```csharp
BigInteger r = Numerics.GetNumberFromGroup(curve.N, curve.Length);
Point multipliedG = Point.Multiply(r, curve.G);
```

### Add two points
```csharp
Point addedPoints = Point.Add(multipliedG, curve.G);
```

### Elliptic-curve Diffie–Hellman
```csharp
Cryptography.KeyPair aliceKeyPair = Cryptography.GetKeyPair(curve);
Cryptography.KeyPair bobKeyPair = Cryptography.GetKeyPair(curve);

Point aliceSharedSecret = Cryptography.GetSharedSecret(aliceKeyPair.PrivateKey, bobKeyPair.PublicKey);
Point bobSharedSecret = Cryptography.GetSharedSecret(bobKeyPair.PrivateKey, aliceKeyPair.PublicKey);
```

## References
* EllipticCurveCrypto (https://github.com/majunkang/EllipticCurveCrypto) under MIT License (https://github.com/majunkang/EllipticCurveCrypto/blob/master/LICENSE) as inspiration
