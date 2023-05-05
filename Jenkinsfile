pipeline {
  agent any
    environment {
      LOGFILE="log${BUILD_NUMBER}"
      DOTNET_ROOT="/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/.NET_6"
      DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
      PATH="${env.PATH}:$DOTNET_ROOT:~/.dotnet/tools/"
      SONAR_HOST_URL="http://192.168.2.63:9000"
  }      
  stages {
    
     stage("Init") {
      steps {
        echo "Init stage"
        echo "LOGFILE = ${env.LOGFILE}"
        echo "DOTNET_ROOT = ${env.DOTNET_ROOT}"
        echo "DOTNET_SYSTEM_GLOBALIZATION_INVARIANT = ${env.DOTNET_SYSTEM_GLOBALIZATION_INVARIANT}"
        echo "PATH = ${env.PATH}"
        echo "SONAR_HOST_URL = ${env.SONAR_HOST_URL}"
       }
    }

    
    stage("Build") {
      steps {
         echo "Running build ${BUILD_ID} on ${JENKINS_URL}, Build URL: ${BUILD_URL}"
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
