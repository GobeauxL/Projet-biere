<?php
class controleur {
	
	public function accueil() {
		$lesCategories = (new categorie)->getAll();
		(new vue)->accueil($lesCategories);
	}
	
	public function erreur404() {
		$lesCategories = (new categorie)->getAll();
		(new vue)->erreur404($lesCategories);
	}

	public function connexion() {
		if(isset($_POST["ok"])) {
			if((new client)->connexion($_POST["email"],$_POST["motdepasse"]))
			{
				$lesCategories = (new categorie)->getAll();
				(new vue)->accueil($lesCategories,false);
			}

			else{
				$lesCategories = (new categorie)->getAll();
				(new vue)->connexion($lesCategories,true);
			}
		}
			else {
				$lesCategories = (new categorie)->getAll();
				(new vue)->connexion($lesCategories,false);
		}
	}

	public function inscription() {
		if(isset($_POST["ok"])) {
			if($_POST["motdepasse"] == $_POST["motdepasse2"] && !(new client)->estDejaInscrit($_POST["email"]))
			{
				$lesCategories = (new categorie)->getAll();
				(new client)->inscriptionClient($_POST["nom"],$_POST["prenom"],$_POST["email"],$_POST["motdepasse"],$_POST["adresse"],$_POST["cp"],$_POST["ville"],$_POST["tel"]);
			}
			elseif((new client)->estDejaInscrit($_POST["email"]))
			{
				$lesCategories = (new categorie)->getAll();
				(new vue)->inscription($lesCategories,true,"L'email est déjà utilisé par un autre compte.");
			}
			elseif($_POST["motdepasse"] != $_POST["motdepasse2"])
			{
				$lesCategories = (new categorie)->getAll();
				(new vue)->inscription($lesCategories,true,"Les mots de passes ne sont pas identiques.");
			}
		}
		else {
			$lesCategories = (new categorie)->getAll();
			(new vue)->inscription($lesCategories, false,"");
		}
	}

	public function produit() {
		if(isset($_GET["id"])) {
			$lesCategories = (new categorie)->getAll();
			$infosArticle = (new produit)->getInfosProduit($_GET["id"]);

			if(count($infosArticle) > 0) {
				$message = null;

				// Action du bouton ajouter au panier sur la page du p 	roduit
				if(isset($_POST["ajoutPanier"]) && isset($_POST["quantite"])) 
				{
					if((new produit)->estDispoEnStock($_POST["quantite"], $_GET["id"])) {
						if(!(isset($_SESSION["panier"]))) 
						{
							$_SESSION["panier"] = array();
							
						}
						for($i = 0; $i < $_POST["quantite"]; $i++) 
						{
							array_push($_SESSION["panier"], $_GET["id"]);
						}
						
						$message = "<label style=\"color:green\">Ajout au panier effectué</label>";
						
					}
					else 
					{
						$message = "<label style=\"color:red\">Erreur lors de l'ajout au panier</label>";
						
					}
				}

				(new vue)->produit($lesCategories, $infosArticle, $message);
			}
			else {
				(new vue)->erreur404($lesCategories);
			}
		}
		else {
			$lesCategories = (new categorie)->getAll();
			(new vue)->erreur404($lesCategories);
		}
	}

	public function panier() {
		$lesCategories = (new categorie)->getAll();
		$lesArticles = array(); // Toutes les infos des produits du panier seront dans cette variable
		foreach($_SESSION["panier"] as $unArticle)
		{
			if(!(isset($lesArticles[$unArticle])))
			{
				$lesArticles[$unArticle]=(new produit)->getInfosProduit($unArticle);
			}
			
		}
			

			// Récupérer toutes les infos des produits dans le panier
			// ... A compléter ...
			(new vue)->panier($lesCategories, $lesArticles, null);
		}
	public function commander() {
		if(isset($_POST["supprimer"])) {
			// Action de suppression d'un produit dans le panier (on mettra le code produit en value du $_POST["supprimer"])

			// ... A compléter ...
		}

		if(isset($_POST["valider"])) {
			// Validation du panier

			/*
				On doit vérifier si l'utilisateur est connecté, si ce n'est pas le cas alors il faut l'inviter à se connecter.
				Si l'utilisateur est connecté alors il faut vérifier que la quantité commandée de chaque produit du panier soit disponbile en stock.
				Si tout est ok alors on créé sa commande dans la base et l'utilisateur doit être averti que sa commande est validée et le panier doit être vidé
				Sinon il faut revenir à la page du panier et avertir l'utilisateur quel produit (préciser sa désignation) pose problème.
			*/

			// ... A compléter ...
		}
	}

	public function categorie() {
		$lesCategories = (new categorie)->getAll();
		$lesArticles = (new categorie)->getProduits($_GET["id"]);
		$nomCategorie = (new categorie)->getNomCategorie($_GET["id"]);
		(new vue)->categorie($lesCategories, $lesArticles, $nomCategorie);
	}

	public function deconnexion() {
		if(isset($_SESSION["connexion"])) {
			unset($_SESSION["connexion"]);
		}

		$this->accueil();
	}
}