#!/bin/sh
# *** DANGER WILL ROBINSON *** This pushd is a hack to ensure that TextTransform is alway run (working directory) inside of 'Build/' 
# xunit does something NASTY under XamarinStudio and fills the bin/Debug folder with System*.dll which borks the t4 scripts.
pushd $(dirname $0)
mono /Applications/Xamarin\ Studio.app/Contents/Resources/lib/monodevelop/AddIns/MonoDevelop.TextTemplating/TextTransform.exe $*
popd

