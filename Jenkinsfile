def buildStatus
def testStatus
def deployStatus

pipeline {
  agent any
    environment {
      LOGFILE="log${BUILD_NUMBER}"
      DOTNET_ROOT="/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/.NET_6"
      DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1
      PATH="${env.PATH}:${DOTNET_ROOT}:/var/jenkins_home/.dotnet/tools/"
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
        
        echo "Workspace = ${WORKSPACE}"
       }
    }

    
  stage("Build") {
      steps {
         echo "Running build stage ${BUILD_ID} on ${JENKINS_URL}, Build URL: ${BUILD_URL}"
        
        dir("${WORKSPACE}/src/DevOpsDemoConsoleApp") {
            sh "dotnet sonarscanner begin /k:\"DemoDevOpsProject\" /d:sonar.host.url=\"http://192.168.2.63:9000\" /d:sonar.login=\"squ_d80cd6e7bedb39a725563df35af64205e50c4a1a\""
            //sh "dotnet build ~/workspace/DevOpsDemoProject/src/DevOpsDemoConsoleApp/DevOpsDemoConsoleApp.sln -c:Release"
             script {
               buildStatus = sh(returnStatus: true, script: "dotnet build ${WORKSPACE}/src/DevOpsDemoConsoleApp/DevOpsDemoConsoleApp.sln -c:Release")
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
        
          // /var/jenkins_home/workspace/OpsDemoProjectDeclarative_master
        
        dir("${WORKSPACE}/test/DevOpsDemoConsoleAppTest/") {
          sh "pwd"
          sh "dotnet test --no-build --nologo --logger \"trx;LogFileName=UnitTests.xml\" ."
          script {
            if (fileExists('./TestResults/UnitTests.xml')) {
                echo "UnitTests.xml results file found!"
            }
          }  
        sh "dotnet test --results-directory TestResults --settings codecoverage.runsettings.xml"
        sh "~/.dotnet/tools/reportgenerator -reports:`find . -name coverage.opencover.xml` -reporttypes:Cobertura -targetdir:coveragereport"
          script { testStatus = 0 }
        }
      }
    }

    stage("Logs") {
      steps {
           script {
            j = "${JOB_NAME}"
            j = j.replace("/${BRANCH_NAME}","")
             if (fileExists("/var/jenkins_home/jobs/${j}/branches/${BRANCH_NAME}/builds/${BUILD_NUMBER}/log")) {
                echo "Log file found!"
                echo "Logs stage"
                sh(script: "cd /var/jenkins_home/jobs/${j}/branches/${BRANCH_NAME}/builds/${BUILD_NUMBER}")
                sh(script: "cp ${WORKSPACE}/DevOpsDemoProject/test/DevOpsDemoConsoleAppTest/TestResults/UnitTests.xml .")
                sh(script: "find ${WORKSPACE}/DevOpsDemoProject/test/DevOpsDemoConsoleAppTest/TestResults/ -name 'coverage.opencover.xml' -exec cp \"{}\" .  \;")
                sh(script: "curl -X GET -u ${BUILD_USER_ID}:Jenkins58k! ${BUILD_URL}/consoleText -o log${BUILD_NUMBER}")
            }
          }  
        
        
//zip Jenkins$BUILD_NUMBER.zip log$BUILD_NUMBER UnitTests.xml coverage.opencover.xml 
//curl -F file1=@Jenkins$BUILD_NUMBER.zip -H "X-API-Key:KNEH369SKRS64T5W7SUFE5XU8FI0HQV7" https://myappformdev.centennialcollege.ca/CencolCoreLibraryWebApi/api/scm/jenkins/log

      }
    }
    
    stage("Deploy") {
      steps {
        echo "Deployment stage"
       }
    }
  }
}
