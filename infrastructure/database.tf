resource "google_bigtable_instance" "instance" {
  name = "instance"
  cluster {
    cluster_id = "cluster-1"
    zone       = "us-central1-a"
    autoscaling_config {
      min_nodes  = 1
      max_nodes  = 5
      cpu_target = 50
    }
  }
  cluster {
    cluster_id = "cluster-2"
    zone       = "us-central1-b"
    autoscaling_config {
      min_nodes  = 1
      max_nodes  = 5
      cpu_target = 50
    }
  }
  cluster {
    cluster_id = "cluster-3"
    zone       = "us-central1-c"
    autoscaling_config {
      min_nodes  = 1
      max_nodes  = 5
      cpu_target = 50
    }
  }
  cluster {
    cluster_id = "cluster-1"
    zone       = "us-west1-a"
    autoscaling_config {
      min_nodes  = 1
      max_nodes  = 5
      cpu_target = 50
    }
  }
  cluster {
    cluster_id = "cluster-2"
    zone       = "us-west1-b"
    autoscaling_config {
      min_nodes  = 1
      max_nodes  = 5
      cpu_target = 50
    }
  }
  cluster {
    cluster_id = "cluster-3"
    zone       = "us-west1-c"
    autoscaling_config {
      min_nodes  = 1
      max_nodes  = 5
      cpu_target = 50
    }
  }
  deletion_protection = "true"
}

resource "google_bigtable_app_profile" "ap" {
  instance       = google_bigtable_instance.instance.name
  app_profile_id = "primary-bt-profile"

  multi_cluster_routing_use_any = true

  ignore_warnings = true
}