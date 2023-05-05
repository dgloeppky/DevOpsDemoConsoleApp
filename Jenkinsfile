pipeline {
  agent any
  
  stages {
    
    stage("Init") {
      steps {
        echo "Init stage"
        sh "EXPORT LOGFILE=log${BUILD_NUMBER}"
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
