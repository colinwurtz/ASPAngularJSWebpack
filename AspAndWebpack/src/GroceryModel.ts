

    // $Classes/Enums/Interfaces(filter)[template][separator]
    // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
    // template: The template to repeat for each matched item
    // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

    // More info: http://frhagn.github.io/Typewriter/

    
    export class GroceryModel {
        
        // GROCERYNAME
        public groceryName: string = null;
        // GROCERYID
        public groceryId: number = null;
        // GROCERYSTORELOCATIONS
        public groceryStoreLocations: string[] = [];
        // QUANTITY
        public quantity: number = 0;
        // LOCATIONID
        public locationId: number = null;
        // CATEGORYID
        public categoryId: number = null;
        // USERID
        public userId: string = null;
    }
