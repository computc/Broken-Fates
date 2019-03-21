#!/usr/bin/env bash

set -x

xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' \
  /opt/Unity/Editor/Unity \
    -projectPath $(pwd) \
    -runTests \
    -testPlatform $TEST_PLATFORM \
    -testResults $(pwd)/$TEST_PLATFORM-results.xml \
    -logFile \
    -manualLicenseFile Unity_v2018.x.ulf \ #May be removed if it doesn't fix the license problem
    -batchmode

UNITY_EXIT_CODE=$?

if [ $UNITY_EXIT_CODE -eq 0 ]; then
  echo "Run succeeded, no failures occurred";
elif [ $UNITY_EXIT_CODE -eq 2 ]; then
  echo "Run succeeded, some tests failed";
elif [ $UNITY_EXIT_CODE -eq 3 ]; then
  echo "Run failure (other failure)";
else
  echo "Unexpected exit code $UNITY_EXIT_CODE";
fi

cat $(pwd)/$TEST_PLATFORM-results.xml | grep test-run | grep Passed
exit $UNITY_TEST_EXIT_CODE