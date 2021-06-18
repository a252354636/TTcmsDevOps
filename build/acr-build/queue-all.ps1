Param(
    [parameter(Mandatory=$false)][string]$acrName,
    [parameter(Mandatory=$false)][string]$gitUser,
    [parameter(Mandatory=$false)][string]$repoName="TTcms",
    [parameter(Mandatory=$false)][string]$gitBranch="dev",
    [parameter(Mandatory=$true)][string]$patToken
)

$gitContext = "https://github.com/$gitUser/$repoName"

$services = @( 
    @{ Name="eshopbasket"; Image="ttcms/basket.api"; File="src/Services/Basket/Basket.API/Dockerfile" },
    @{ Name="eshopcatalog"; Image="ttcms/catalog.api"; File="src/Services/Catalog/Catalog.API/Dockerfile" },
    @{ Name="eshopidentity"; Image="ttcms/identity.api"; File="src/Services/Identity/Identity.API/Dockerfile" },
    @{ Name="eshopordering"; Image="ttcms/ordering.api"; File="src/Services/Ordering/Ordering.API/Dockerfile" },
	@{ Name="eshoporderingbg"; Image="ttcms/ordering.backgroundtasks"; File="src/Services/Ordering/Ordering.BackgroundTasks/Dockerfile" },
    @{ Name="eshopwebspa"; Image="ttcms/webspa"; File="src/Web/WebSPA/Dockerfile" },
    @{ Name="eshopwebmvc"; Image="ttcms/webmvc"; File="src/Web/WebMVC/Dockerfile" },
    @{ Name="eshopwebstatus"; Image="ttcms/webstatus"; File="src/Web/WebStatus/Dockerfile" },
    @{ Name="eshoppayment"; Image="ttcms/payment.api"; File="src/Services/Payment/Payment.API/Dockerfile" },
    @{ Name="eshopocelotapigw"; Image="ttcms/ocelotapigw"; File="src/ApiGateways/ApiGw-Base/Dockerfile" },
    @{ Name="eshopmobileshoppingagg"; Image="ttcms/mobileshoppingagg"; File="src/ApiGateways/Mobile.Bff.Shopping/aggregator/Dockerfile" },
    @{ Name="eshopwebshoppingagg"; Image="ttcms/webshoppingagg"; File="src/ApiGateways/Web.Bff.Shopping/aggregator/Dockerfile" },
    @{ Name="eshoporderingsignalrhub"; Image="ttcms/ordering.signalrhub"; File="src/Services/Ordering/Ordering.SignalrHub/Dockerfile" }
)

$services |% {
    $bname = $_.Name
    $bimg = $_.Image
    $bfile = $_.File
    Write-Host "Setting ACR build $bname ($bimg)"    
    az acr build-task create --registry $acrName --name $bname --image ${bimg}:$gitBranch --context $gitContext --branch $gitBranch --git-access-token $patToken --file $bfile
}

# Basket.API
