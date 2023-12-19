# TCTC


## V 2.2.0

New card
- Rocket Launcher
	- Only available if TurretsPhysicsPatch is installed

- new art
	- none :(

Balance changes

- Resit
	- re-enabled 
	- fix for duplicate or incompatable cards (hopefully)

- Class II weight estimation
	- increased health (+80% to +100%)
	- decreased size (-10% to -20%)

- Re-entry
	- disallowed duplicates

- Compact Teleporter
	- disallowed duplicates
	- increased ammo (+0 to +4)

- Rapid unplanned disasembly
	- User now explodes 0.5 seconds after last block
		- this should fix the unintended interaction with multiple blocks
	- Now also deals aditional direct damage to the user

- Quadro acceleration
	- increased health (-30% to -10%)

- Streamlined
	- increased health (-40% to -20%)

- Design space
	- damage increased (-80% to -75%)

## V 2.1.0

New card
- Re-entry

new art
- Re-entry

Removed cards
- AE student class 
	- Resit
	- Bonus points

Fixes
- Compact teleporter
	- Wall colision during teleport disabled
- Guess cards
	- Buffs now correctly synced between players


## V 2.0.1

Balance changes

- AE class 
	- Projects
		- removed the stress damage 
		- decreased health of Design and construction (+200% to + 150%)
		- decreased movement speed of Systems Design (+50% to +30%)

	- AE class card
		- Added damage per ECTS (+0% to +1%)

## V 2.0.0

Thunderstore

- changelog 
	- the old readme has been moved to this changelog
- readme
	- new readme
- discription
	- added the AE class to the discription


fixes

- Rapid unplanned disasembly
	- added automatic deletion for the left over gameobjects after an explosion


Balance changes

- Rapid unplanned disasembly
	- Explosion now scales with max health (The original damage is now the damage at starting health and it is directly proportional)

- Guess cards 
	- decreased the delta in the effect of the buffs and debuffs

- Waffle
	- decreased regen (30 to 25)

- DesignSpace
	- Increased Damage (-95% to -80%)

Added dependencies

- Rarity lib
- Classes manager reborn


new cards

- AE student class (new class)
	- Statics
	- Dynamics
	- Calculus 1 part 1
	- Calculus 1 part 2
	- Calculus 2 
	- Linear Algebra
	- Differential equations
	- Propability and Statistics
	- Introduction to aerospace engineering 1
	- Introduction to aerospace engineering 2
	- Materials
	- Mechanics of materials
	- Thermodynamics
	- Electromagnetism
	- ADSEE1
	- ADSEE2
	- Aerodynamics 1
	- Aerodynamics 2
	- Aerospace Design and Construction
	- Exploring Aerospace Engineering
	- Systems Design
	- Test, Analysis and Simulation
	- Minor
	- Flight and Orbital Mechanics
	- Power and Propulsion
	- Simulation, Verification and Validation
	- Flight Dynamics
	- DSE
	- Resit
	- Bonus Points


new art

- Statics now has art
- Dynamics now has art
- Differential equations now has art
- Aerospace Design and Construction now has art
- Aerodynamics 1 now has art
- Streamlined now has art
- Aerodynamics 2 now has art
- Aerospace Engineering Student Class now has art
- Flight Dynamics now has art
- Graduation cap now exists

## V 1.2.2

fixes
- Both coffee and quadro acceleration were giving attackspeed down this has now been fixed
- Both coffee and quadro acceleration were applying stats to the wrong variable

Balance changes
- Streamlined
	- increased health (-50% to -40%)
- Waffle
	- decreased health (0 to -20%)

new art
- Assumption now has art


## V 1.2.1

fixes
- Changed the description of coffee to accurately reflect what the card does.
	- attackspeed (+30% to +20%)
	- block cooldown (-20% to -10%)


UI
- The Guess cards now show which effect is active. (top of the screen)

new art
- Blind Guess now has art
- Educated Guess now has art
- No Guess Work now has art
- Class II weight estimation now has art 





## v 1.2.0

fixes
- Guess cards
	- changed the rounding for the selection so it should not favor 1 option over the others


new art
- Coffee now has art

new card
- rapid unplanned disasembly



## v 1.1.1

Balance changes to
- Guess cards 
	- changes to the buffs and debuffs
		- removed damage over time and regen, replaced with bullets + and -
	- changed the time from 10 seconds to 5 seconds
	- The issue was that the round starting would clear the effects, with this shorter timer the issue should be less noticable.
- Streamlined
	- increased movement speed (+50% to +60%)
- Quadro acceleration
	- increased movement speed (+25% to +30%)
	- increased attackspeed (+20% to +25%)




## v 1.1.0 

Balance changes to
- Guess cards 
	- changes to the buffs and debuffs
		- Damage over time added and regen instead of health
		- greater effects for both the buffs and debuffs
	- I am working on a fix for educated guess and no guess work not triggering, they seem to be working in sandbox but not in multiplayer
- The end is nigh
	- lowered time to kill
	- increased stats
- Assumption
	- changed the cooldown multiplier (-30% to -20%)

Added this readme :)

Added new card

- Class II weight estimation
	



## v 1.0.0

Initial release