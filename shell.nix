{ pkgs ? import <nixpkgs> {} }:

(pkgs.buildFHSEnv {
  name = "codecrafters-http-server-csharp";
  targetPkgs = pkgs: (with pkgs; [
    dotnetCorePackages.dotnet_9.sdk
    fish
    jetbrains.rider
  ]);
  multiPkgs = pkgs: (with pkgs; [
  ]);
  runScript = "fish";
}).env
