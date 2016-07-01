#!/bin/sh
BASEDIR=$(dirname $0)
ROOTDIR=$BASEDIR/..
mono $ROOTDIR/packages/xunit.runner.console.2.0.0/tools/xunit.console.exe $*

# Not currently working: https://github.com/xunit/xunit/issues/158 (waiting for fix in mono).
