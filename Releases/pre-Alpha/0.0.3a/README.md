﻿*** **ALPHA RELEASE WARNING** ****

Alpha versions, as usual, buggy and unstable, use this to take a look only before beta and final release.

EXPECT BUGS, UNUSUAL BEHAVIOR, AND MAYBE ERRORS DURING INSTALL AND OPERATION

﻿*** **ALPHA RELEASE WARNING** ****

**Current version: 0.0.3a - Download from "release" on top of the page**

**Version 0.0.3a:**
* SERVICE: Fixed the code which the service use to grab the accounting data in order to display the correct numbers.
* SERVICE: There is a bug where the service will crash if the computer goes into sleep mode then resume after.
* GUI: We can now have a full user report viewed from the menu: Reports -> Single user reports -> View single user report.
* GUI: Added chart controls to make reports more convenient, but will need more testing and work on it.


* full_package_003a.7z:
Contains the GUI version and the service version as well.
If you download this, you need to go to Setup menu, then Database server, in order to configure the database connection.

* Service_install_003a.7z:
Contains only the service executable file, this can be used if you want to separate the service from GUI, and have each one on a different computer.
If you download this, MAKE SURE you read the guide on how to configure the service to connect to a database instance from here [Standalone service configuration guide](https://github.com/salehram/mikrotik-proxy-logger/wiki/Standalone-service-configuration-guide)
