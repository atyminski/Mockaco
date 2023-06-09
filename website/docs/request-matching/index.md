
# Request Matching

When a request is received, Mockaco follows a specific process:

Mockaco searches for files in alphabetical order.
1. It compares the request against the criteria specified in the request object of each file.
2. The first match that meets the criteria is selected.
3. If no matching Mock file is found, Mockaco returns a default response of HTTP 501 (Not Implemented). Additionally, it provides a list of possible file parsing errors.

This process ensures that Mockaco handles incoming requests and provides appropriate responses based on the available mock files. In case of any errors, the default response serves as a helpful indicator for troubleshooting.