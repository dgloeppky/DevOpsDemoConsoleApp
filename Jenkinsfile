pipeline {
  agent any
  environment { 
    LOGFILE="log${BUILD_NUMBER}"
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
    DOTNET_ROOT=/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/.NET_6
    PATH="$PATH:$DOTNET_ROOT"
    PATH="$PATH:~/.dotnet/tools/"
    SONAR_HOST_URL=http://192.168.2.63:9000
  }
  
  stages {
    
    stage("Init") {
      steps {
        echo "Init stage"
        echo "LOGFILE = ${LOGFILE}"
        echo "DOTNET_ROOT = ${DOTNET_ROOT}"
        echo "PATH = ${PATH}"
       }
    }

    
    stage("Build") {
      steps {
        echo "Build stage"
       }
    }

    stage("Test") {
      steps {
        echo "Test stage"
       }
    }


    stage("Deploy") {
      steps {
        echo "Deployment stage"
       }
    }
  }
}
