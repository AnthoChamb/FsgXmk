# FsgXmk

[![build status](https://github.com/AnthoChamb/FsgXmk/actions/workflows/build.yml/badge.svg)](https://github.com/AnthoChamb/FsgXmk/actions/workflows/build.yml)

.NET class libraries for managing FSG XMK files.

## FsgXmk

[![latest version](https://img.shields.io/nuget/v/FsgXmk)](https://www.nuget.org/packages/FsgXmk) [![downloads](https://img.shields.io/nuget/dt/FsgXmk)](https://www.nuget.org/packages/FsgXmk)

Default implementation for FsgXmk.

### Installation

FsgXmk is available on [NuGet](https://www.nuget.org/packages/FsgXmk).

```sh
dotnet add package FsgXmk
```

Use the `--version` option to specify a [version](https://www.nuget.org/packages/FsgXmk#versions-body-tab) to install.

### Usage

The following code demonstrates usage of FsgXmk.

```cs
using var reader = new XmkStreamReader(File.OpenRead("guitar_3x2.xmk"));
var xmk = reader.Read();
```

## FsgXmk.Kaitai

[![latest version](https://img.shields.io/nuget/v/FsgXmk.Kaitai)](https://www.nuget.org/packages/FsgXmk.Kaitai) [![downloads](https://img.shields.io/nuget/dt/FsgXmk.Kaitai)](https://www.nuget.org/packages/FsgXmk.Kaitai)

[Kaitai Struct](https://kaitai.io) implementation for FsgXmk.

### Installation

FsgXmk.Kaitai is available on [NuGet](https://www.nuget.org/packages/FsgXmk.Kaitai).

```sh
dotnet add package FsgXmk.Kaitai
```

Use the `--version` option to specify a [version](https://www.nuget.org/packages/FsgXmk.Kaitai#versions-body-tab) to install.

### Usage

The following code demonstrates usage of FsgXmk.Kaitai.

```cs
using var reader = new KaitaiXmkStreamReader(new KaitaiStream("guitar_3x2.xmk"));
var xmk = reader.Read();
```
