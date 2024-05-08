# Docker developer configuration

## Overview
1. Core developer database `dev-core-db`
Configured ports: 4000

2. Crm developer database `dev-crm-db`
Configured ports: 4001

3. Identity developer database `dev-identity-db`
Configured ports: 4500

4. Redis Cache `redis-cache`
Configured ports: 8000

These databases are aimed to be running on a developer machine and not on a production server so default passwords are provided in the `compose.yaml`