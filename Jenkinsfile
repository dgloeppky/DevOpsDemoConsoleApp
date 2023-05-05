pipeline {
  agent any
  environment { 
    sh "EXPORT LOGFILE=log${BUILD_NUMBER}"
  }
  
  stages {
    
    stage("Init") {
      steps {
        echo "Init stage"
        echo "LOGFILE = ${LOGFILE}"
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
