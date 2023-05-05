def buildStatus
def testStatus
def deployStatus

pipeline {
  agent any
    options { skipDefaultCheckout() }
    environment {
      LOGFILE="log${BUILD_NUMBER}"
      DOTNET_ROOT="/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/.NET_6"
      DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
      PATH="${env.PATH}:$DOTNET_ROOT:/var/jenkins_home/.dotnet/tools/"
      SONAR_HOST_URL="http://192.168.2.63:9000"
  }      
  stages {
    
     stage('CleanWorkspace') {
            steps {
                cleanWs()
            }
        }
    
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
         echo "Running build stage ${BUILD_ID} on ${JENKINS_URL}, Build URL: ${BUILD_URL}"
         dir('/var/jenkins_home/workspace/OpsDemoProjectDeclarative_master/src/DevOpsDemoConsoleApp') {
            sh "dotnet sonarscanner begin /k:\"DemoDevOpsProject\" /d:sonar.host.url=\"http://192.168.2.63:9000\" /d:sonar.login=\"squ_d80cd6e7bedb39a725563df35af64205e50c4a1a\""
            //sh "dotnet build ~/workspace/DevOpsDemoProject/src/DevOpsDemoConsoleApp/DevOpsDemoConsoleApp.sln -c:Release"
             script {
                    buildStatus = sh(returnStatus: true, script: "dotnet build /var/jenkins_home/workspace/OpsDemoProjectDeclarative_master/src/DevOpsDemoConsoleApp/DevOpsDemoConsoleApp.sln -c:Release")
                }
            sh "dotnet sonarscanner end /d:sonar.login=\"squ_d80cd6e7bedb39a725563df35af64205e50c4a1a\""
         }
       }
    }

    stage("Test") {
      when {
          expression { buildStatus == 0  }    
      }
      steps {
        echo "Running test stage ${BUILD_ID}"
        //script {
        //    if (buildStatus != 0) {
        //      echo "Error: Command exited with status ${status}"
        //    } else {
        //      echo "Command executed successfully"
        //      sh "pwd"
        //    }        
        //  }
        
        echo "The job url: ${JOB_URL}"
        
          sh "cd /var/jenkins_home/workspace/OpsDemoProjectDeclarative_master/test/DevOpsDemoConsoleAppTest/"
          sh "dotnet test --no-build --nologo --logger \"trx;LogFileName=UnitTests.xml\" /var/jenkins_home/workspace/OpsDemoProjectDeclarative_master/test/DevOpsDemoConsoleAppTest/"
          sh "dotnet test --results-directory TestResults --settings codecoverage.runsettings.xml"
          sh "~/.dotnet/tools/reportgenerator -reports:`find . -name coverage.opencover.xml` -reporttypes:Cobertura -targetdir:coveragereport"
    
      }
    }

    stage("Deploy") {
      steps {
        echo "Deployment stage"
       }
    }
  }
}
